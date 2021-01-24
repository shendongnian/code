        var fileList = Directory.GetFiles(@"E:\TUTORIALS\");
        string[] filePaths = Directory.GetFiles(@"E:\TUTORIALS\", "", SearchOption.AllDirectories);
        for (int i = 1; i < fileList.Length; i++)
        {
            try
            {
                var from = System.IO.Path.Combine(@"E:\TUTORIALS\"+ System.IO.Path.GetFileName(filePaths.FirstOrDefault()));
                var to = System.IO.Path.Combine(@"E:\Vid\"+ System.IO.Path.GetFileName(filePaths.FirstOrDefault()));
                var currentFileName = to; 
                var newFileName = i.ToString("000")+"."+Path.GetFileName( Path.GetDirectoryName( currentFileName) )+"."+Path.GetFileName(to); 
                File.Move(from, to); // Try to move
                File.Move(currentFileName,newFileName); //Renaming aftermoving
                Console.WriteLine("Moved"+ filePaths.FirstOrDefault()); // Success
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex); // Write error
            }
        }
