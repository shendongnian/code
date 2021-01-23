    public class CreateFileOrFolder
    {
        static void Main()
        {
            // Specify a "currently active folder"
            string activeDir = @"c:\testdir2";
    
            //Create a new subfolder under the current active folder
            string newPath = System.IO.Path.Combine(activeDir, "mySubDir");
    
            // Create the subfolder
            System.IO.Directory.CreateDirectory(newPath);
    
            // Create a new file name. This example generates a random string.
            string newFileName = System.IO.Path.GetRandomFileName();
    
            // Combine the new file name with the path
            newPath = System.IO.Path.Combine(newPath, newFileName);
    
            // Create the file and write to it.
            // DANGER: System.IO.File.Create will overwrite the file
            // if it already exists. This can occur even with random file names.
            if (!System.IO.File.Exists(newPath))
            {
                using (System.IO.FileStream fs = System.IO.File.Create(newPath))
                {
                    for (byte i = 0; i < 100; i++)
                    {
                        fs.WriteByte(i);
                    }
                }
            }
    
            // Read data back from the file to prove that the previous code worked.
            try
            {
                byte[] readBuffer = System.IO.File.ReadAllBytes(newPath);
                foreach (byte b in readBuffer)
                {
                    Console.WriteLine(b);
                }
            }
            catch (System.IO.IOException e)
            {
                Console.WriteLine(e.Message);
            }
    
            // Keep the console window open in debug mode.
            System.Console.WriteLine("Press any key to exit.");
            System.Console.ReadKey();
        }
    }
