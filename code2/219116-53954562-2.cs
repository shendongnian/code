       public async Task InitializeAsync()
        {
            //TODO: Use a semaphore lock here
            if (_IsInitializing)
            {
                return;
            }
            _IsInitializing = true;
            try
            {
                //TODO:
                //Dispose();
                var isPermissionGranted = await RequestPermissionAsync();
                if (!isPermissionGranted.HasValue)
                {
                    throw new Exception("User did not respond to permission request");
                }
                if (!isPermissionGranted.Value)
                {
                    throw new Exception("The user did not give the permission to access the device");
                }
                var usbInterface = _UsbDevice.GetInterface(0);
                //TODO: This selection stuff needs to be moved up higher. The constructor should take these arguments
                for (var i = 0; i < usbInterface.EndpointCount; i++)
                {
                    var ep = usbInterface.GetEndpoint(i);
                    if (_ReadEndpoint == null && ep.Type == UsbAddressing.XferInterrupt && ep.Address == (UsbAddressing)129)
                    {
                        _ReadEndpoint = ep;
                        continue;
                    }
                    if (_WriteEndpoint == null && ep.Type == UsbAddressing.XferInterrupt && (ep.Address == (UsbAddressing)1 || ep.Address == (UsbAddressing)2))
                    {
                        _WriteEndpoint = ep;
                    }
                }
                //TODO: This is a bit of a guess. It only kicks in if the previous code fails. This needs to be reworked for different devices
                if (_ReadEndpoint == null)
                {
                    _ReadEndpoint = usbInterface.GetEndpoint(0);
                }
                if (_WriteEndpoint == null)
                {
                    _WriteEndpoint = usbInterface.GetEndpoint(1);
                }
                if (_ReadEndpoint.MaxPacketSize != ReadBufferLength)
                {
                    throw new Exception("Wrong packet size for read endpoint");
                }
                if (_WriteEndpoint.MaxPacketSize != ReadBufferLength)
                {
                    throw new Exception("Wrong packet size for write endpoint");
                }
                _UsbDeviceConnection = UsbManager.OpenDevice(_UsbDevice);
                if (_UsbDeviceConnection == null)
                {
                    throw new Exception("could not open connection");
                }
                if (!_UsbDeviceConnection.ClaimInterface(usbInterface, true))
                {
                    throw new Exception("could not claim interface");
                }
                Logger.Log("Hid device initialized. About to tell everyone.", null, LogSection);
                IsInitialized = true;
                RaiseConnected();
                return;
            }
            catch (Exception ex)
            {
                Logger.Log("Error initializing Hid Device", ex, LogSection);
            }
            _IsInitializing = false;
        }
        public override async Task<byte[]> ReadAsync()
        {
            try
            {
                var byteBuffer = ByteBuffer.Allocate(ReadBufferLength);
                var request = new UsbRequest();
                request.Initialize(_UsbDeviceConnection, _ReadEndpoint);
                request.Queue(byteBuffer, ReadBufferLength);
                await _UsbDeviceConnection.RequestWaitAsync();
                var buffers = new byte[ReadBufferLength];
                byteBuffer.Rewind();
                for (var i = 0; i < ReadBufferLength; i++)
                {
                    buffers[i] = (byte)byteBuffer.Get();
                }
                //Marshal.Copy(byteBuffer.GetDirectBufferAddress(), buffers, 0, ReadBufferLength);
                Tracer?.Trace(false, buffers);
                return buffers;
            }
            catch (Exception ex)
            {
                Logger.Log(Helpers.ReadErrorMessage, ex, LogSection);
                throw new IOException(Helpers.ReadErrorMessage, ex);
            }
        }
        public  override async Task WriteAsync(byte[] data)
        {
            try
            {
                var request = new UsbRequest();
                request.Initialize(_UsbDeviceConnection, _WriteEndpoint);
                var byteBuffer = ByteBuffer.Wrap(data);
                Tracer?.Trace(true, data);
                request.Queue(byteBuffer, data.Length);
                await _UsbDeviceConnection.RequestWaitAsync();
            }
            catch (Exception ex)
            {
                Logger.Log(Helpers.WriteErrorMessage, ex, LogSection);
                throw new IOException(Helpers.WriteErrorMessage, ex);
            }
        }
        
