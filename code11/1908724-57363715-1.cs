          // Setting The WaveFormat for the device
                            WaveFormat w = new WaveFormat(44100, 16, 2);
                            PropVariant p = new PropVariant();
                            p.pointerValue = WaveFormatToPointer(w);
                            
        
        selectedRecordingDevice.GetPropertyInformation(StorageAccessMode.ReadWrite);
            
            
      
      
      selectedRecordingDevices.Properties.SetValue(PropertyKeys.PKEY_AudioEngine_DeviceFormat, p);
