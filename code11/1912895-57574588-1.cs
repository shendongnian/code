      public static void Logger(string lines)
        {
            string path = "C:/Log/";
            VerifyYourPath(path);
            string fileName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +
           DateTime.Now.Year.ToString() + "_Logs.txt";
            if (Exist(fileName))// Check you already have this file or not
            {
                // add the new lines to exisiting file
            }
            else
            {
                try
                {
                    System.IO.StreamWriter file = new System.IO.StreamWriter(path + fileName, true);
                    var title = DateTime.Now.ToString()/*What you want*/;
                    file.WriteLine(title + ": " + lines);
                    file.Close();
                }
                catch (Exception) { }
            }
        }
