    MemoryMappedFile file = MemoryMappedFile.CreateOrOpen(@"Global\MyMemoryMappedFile", 4096, 
    MemoryMappedFileAccess.ReadWrite, MemoryMappedFileOptions.DelayAllocatePages, mmfSecurity, 
    HandleInheritability.Inheritable);
    
    using (MemoryMappedViewAccessor accessor = file.CreateViewAccessor()) {
       string xmlData = SerializeToXml(CurrentJobQueue) + "\0"; // \0 terminates the XML to stop badly formed 
    issues when the next string written is shorter than the current
    
        byte[] buffer = ConvertStringToByteArray(xmlData);
        mutex.WaitOne();
        accessor.WriteArray<byte>(0, buffer, 0, buffer.Length);
        mutex.ReleaseMutex();
        }
