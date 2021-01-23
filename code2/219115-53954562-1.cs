        public override async Task InitializeAsync()
        {
            await GetDevice(DeviceId);
            if (_ConnectedDevice != null)
            {
                var usbInterface = _ConnectedDevice.Configuration.UsbInterfaces.FirstOrDefault();
                if (usbInterface == null)
                {
                    _ConnectedDevice.Dispose();
                    throw new Exception("There was no Usb Interface found for the device.");
                }
                var interruptPipe = usbInterface.InterruptInPipes.FirstOrDefault();
                if (interruptPipe == null)
                {
                    throw new Exception("There was no interrupt pipe found on the interface");
                }
                interruptPipe.DataReceived += InterruptPipe_DataReceived;
                RaiseConnected();
            }
            else
            {
                throw new Exception($"Could not connect to device with Device Id {DeviceId}. Check that the package manifest has been configured to allow this device.");
            }
        }
        public override async Task WriteAsync(byte[] bytes)
        {
            var bufferToSend = bytes.AsBuffer();
            var usbInterface = _ConnectedDevice.Configuration.UsbInterfaces.FirstOrDefault();
            var outPipe = usbInterface.InterruptOutPipes.FirstOrDefault();
            await outPipe.OutputStream.WriteAsync(bufferToSend);
            Tracer?.Trace(false, bytes);
        }
        public override async Task<byte[]> ReadAsync()
        {
            if (_IsReading)
            {
                throw new Exception("Reentry");
            }
            lock (_Chunks)
            {
                if (_Chunks.Count > 0)
                {
                    var retVal = _Chunks[0];
                    Tracer?.Trace(false, retVal);
                    _Chunks.RemoveAt(0);
                    return retVal;
                }
            }
            _IsReading = true;
            _TaskCompletionSource = new TaskCompletionSource<byte[]>();
            return await _TaskCompletionSource.Task;
        }
