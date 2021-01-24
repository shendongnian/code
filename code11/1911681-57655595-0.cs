    async void InitializeService()
    {
        var localRfcommProvider = await RfcommServiceProvider.CreateAsync(Constants.RfcommServiceUuid);
        var rfcommServiceID = RfcommServiceId.FromUuid(Constants.RfcommServiceUuid);
        socketListener = new StreamSocketListener();
        socketListener.ConnectionReceived += SocketListener_ConnectionReceived;      
        await socketListener.BindServiceNameAsync(rfcommServiceID.AsString(),SocketProtectionLevel.BluetoothEncryptionAllowNullAuthentication);
        InitializeServiceSdpAttributes(localRfcommProvider);
        try
        {
            ((Windows.Devices.Bluetooth.Rfcomm.RfcommServiceProvider)localRfcommProvider).StartAdvertising(socketListener);  
        }
        catch (Exception e)
        {
                Debug.WriteLine(e.Message);
        }
    }
    void InitializeServiceSdpAttributes(Windows.Devices.Bluetooth.Rfcomm.RfcommServiceProvider provider)
        {
            var sdpWriter = new DataWriter();
            //Write the service name attribute
            sdpWriter.WriteByte(Constants.SdpServiceNameAttributeType);
            // The length of the UTF-8 encoded Service Name SDP Attribute.
            sdpWriter.WriteByte((byte)Constants.SdpServiceName.Length);
            // The UTF-8 encoded Service Name value.
            sdpWriter.UnicodeEncoding = Windows.Storage.Streams.UnicodeEncoding.Utf8;
            sdpWriter.WriteString(Constants.SdpServiceName);
            // Set the SDP Attribute on the RFCOMM Service Provider.
            provider.SdpRawAttributes.Add(Constants.SdpServiceNameAttributeId, sdpWriter.DetachBuffer());
        }
