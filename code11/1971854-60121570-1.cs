    private static void Kernel_FileIORead(Microsoft.Diagnostics.Tracing.Parsers.Kernel.FileIOReadWriteTraceData obj)
     {
        var fName = Path.GetFileNameWithoutExtension(obj.FileName);
        if(fName.ToUpper().StartsWith("E"))
        {
          Console.WriteLine("1:" + fName);
        }
                           
     }
