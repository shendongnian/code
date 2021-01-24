       string[] filePathscount = Directory.GetFiles(@"E:\Vid\", "", SearchOption.AllDirectories);
            for (int i = 1; i < filePathscount.Length; i++)
            {
                string[] filePaths = Directory.GetFiles(@"E:\Vid\", "", SearchOption.AllDirectories);
                try
                {
                    var from = System.IO.Path.Combine( System.IO.Path.GetFullPath(filePaths.FirstOrDefault()));
                    var to = System.IO.Path.Combine(@"E:\Vid2\" + System.IO.Path.GetFileName(filePaths.FirstOrDefault()));
                    var currentFileName = to;
                    var newFileName = i.ToString("000") + "." + Path.GetFileName(Path.GetDirectoryName(currentFileName)) + "." + Path.GetFileName(to);
                    File.Move(from, to); // Try to move
                    File.Move(currentFileName, newFileName); //Renaming aftermoving
                    Console.WriteLine("Moved " + filePaths.FirstOrDefault()); // Success
                }
                catch (IOException ex)
                {
                    Console.WriteLine(ex); // Write error
                }
            }
