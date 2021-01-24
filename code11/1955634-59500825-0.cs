            DirectoryObject[] devices = new DirectoryObject[2];
            DirectoryObject directoryObject = new DirectoryObject();
            directoryObject.DeletedDateTime = DateTimeOffset.Now;
            devices[0] = directoryObject;
            ManagedDevice[] devicesToAdd = new ManagedDevice[2];
            ManagedDevice managedDevice = new ManagedDevice();
            devicesToAdd[0] = managedDevice;
            Entity[] entityArray = new Entity[devices.Length + devicesToAdd.Length];
            Array.Copy(devices, entityArray, devices.Length);
            Array.Copy(devicesToAdd, 0, entityArray, devices.Length, devicesToAdd.Length);
            foreach(var entity in entityArray)
            {
                if(entity is DirectoryObject)
                {
                    var castedObject = (DirectoryObject)entity;
                    var dateTime = castedObject.DeletedDateTime;
                }
                if(entity is ManagedDevice)
                {
                }
            }
