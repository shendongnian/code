      using(var inputFile = new FileStream(
             "oldFile.txt", 
             FileMode.Open, 
             FileAccess.Read, 
             FileShare.ReadWrite))
         {
            using (var outputFile = new FileStream("newFile.txt", FileMode.Create))
            { 
                var buffer = new byte[0x10000];
                var bytes;
    
                while ((bytes = inputFile.Read(buffer, 0, buffer.Length)) > 0) 
                {
                    outputFile.Write(buffer, 0, bytes);
                }
            }
        }
