    class NotificationClientImplementation : NAudio.CoreAudioApi.Interfaces.IMMNotificationClient
        {
    		
            public void OnDefaultDeviceChanged(DataFlow dataFlow, Role deviceRole, string defaultDeviceId)
            {
    			//Do some Work
                Console.WriteLine("OnDefaultDeviceChanged --> {0}", dataFlow.ToString());
            }
    
            public void OnDeviceAdded(string deviceId)
            {
                 //Do some Work
                Console.WriteLine("OnDeviceAdded -->");
            }
    
            public void OnDeviceRemoved(string deviceId)
            {
                
                Console.WriteLine("OnDeviceRemoved -->");
                 //Do some Work
            }
    
            public void OnDeviceStateChanged(string deviceId, DeviceState newState)
            {
                Console.WriteLine("OnDeviceStateChanged\n Device Id -->{0} : Device State {1}", deviceId, newState);
                 //Do some Work
            }
    
            public NotificationClientImplementation()
            {
                //_realEnumerator.RegisterEndpointNotificationCallback();
                if (System.Environment.OSVersion.Version.Major < 6)
                {
                    throw new NotSupportedException("This functionality is only supported on Windows Vista or newer.");
                }
            }
    
            public void OnPropertyValueChanged(string deviceId, PropertyKey propertyKey)
            {
                 //Do some Work
                 //fmtid & pid are changed to formatId and propertyId in the latest version NAudio
                Console.WriteLine("OnPropertyValueChanged: formatId --> {0}  propertyId --> {1}", propertyKey.formatId.ToString(), propertyKey.propertyId.ToString());
            }
         
        }
