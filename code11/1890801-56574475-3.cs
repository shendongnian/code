    char[] invalidChars = Path.GetInvalidFileNameChars();
    string logFile = Path.Combine(targetdir, "log.txt");
    try
    {
       using(StreamWriter sw = new StreamWriter(logFile))
       {
           foreach (string item in File.ReadLines(csv))
           {
               if(item.Any(x => invalidChars.Contains(x)))
                    sw.WriteLine(item + " BAD");
               else
               {
                    Directory.CreateDirectory(Path.Combine(targetdir,item));
                    sw.WriteLine(item + " OK!");                    
               }
           }
        }                
        MessageBox.Show("Done");
    }
    catch(Exception ex)
    {
        MessageBox.Show(ex.Message);
    }
