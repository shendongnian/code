    string sqllitefile = "sqllite.dll";
    Assembly currentAssembly = Assembly.GetExecutingAssembly();
    using (FileStream fs = fileInfoOutputFile.OpenWrite())
    using (Stream resourceStream =currentAssembly.GetManifestResourceStream(sqllitefile))
    {
       const int size = 4096;
       byte[] bytes = new byte[4096];
       int numBytes;
       while ((numBytes = resourceStream.Read(bytes, 0, size)) > 0) 
       {
             fs.Write(bytes, 0, numBytes);
       }
       fs.Flush();
       fs.Close();
       resourceStream.Close();
    }
