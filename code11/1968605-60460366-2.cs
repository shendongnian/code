    using (MemoryMappedFile file = MemoryMappedFile.OpenExisting(
       @"Global\MyMemoryMappedFile", MemoryMappedFileRights.Read)) {
                                   
         using (MemoryMappedViewAccessor accessor =
             file.CreateViewAccessor(0, 0, MemoryMappedFileAccess.Read)) {
             byte[] buffer = new byte[accessor.Capacity];
                                        
             Mutex mutex = Mutex.OpenExisting(@"Global\MyMutex");
             mutex.WaitOne();
             accessor.ReadArray<byte>(0, buffer, 0, buffer.Length);
             mutex.ReleaseMutex();
                                       
             string xmlData = ConvertByteArrayToString(buffer);
             data = DeserializeFromXML(xmlData);
           }
