    public static void Logger(string lines)
        {
            string path = "C:/Log/";
            VerifyYourPath(path);
            string fileName = DateTime.Now.Day.ToString() + DateTime.Now.Month.ToString() +
           DateTime.Now.Year.ToString() + "_Logs.txt";
            try
            {
                System.IO.StreamWriter file = new System.IO.StreamWriter(path + fileName, true);
                file.WriteLine(DateTime.Now.ToString()/*What you want*/ + ": " + lines);
                file.Close();
            }
            catch (Exception) { }
        }
