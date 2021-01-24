      using (var file = File.OpenRead(filePath)) {
          int bytesRead;
          var buffer = new byte[chunkSize];
          while ((bytesRead = file.Read(buffer, 0, buffer.Length)) > 0) {
               if (bytesRead < buffer.Length)
               {
                   var smallBuffer = new byte[bytesRead];
                   Array.Copy(buffer, 0, smallBuffer, 0, bytesRead);
                   Send(ns, smallBuffer);
               }
               else
               {
                   Send(ns, buffer);
               }
          }
