    public void SaveLogFile(object method, Exception exception)
    {
        string location = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + @"\FolderName\";
        try
        {
            //Opens a new file stream which allows asynchronous reading and writing
            using (StreamWriter sw = new StreamWriter(new FileStream(location + @"log.txt", FileMode.Append, FileAccess.Write, FileShare.ReadWrite)))
            {
                //Writes the method name with the exception and writes the exception underneath
                sw.WriteLine(String.Format("{0} ({1}) - Method: {2}", DateTime.Now.ToShortDateString(), DateTime.Now.ToShortTimeString(), method.ToString()));
                sw.WriteLine(exception.ToString()); sw.WriteLine("");
            }
        }
        catch (IOException)
        {
            if (!File.Exists(location + @"log.txt"))
            {
                File.Create(location + @"log.txt");
            }
        }
    }
