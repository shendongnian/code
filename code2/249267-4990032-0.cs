    DirectoryInfo di = new DirectoryInfo(ConfigurationManager.AppSettings["BilixFilesDir"]);
    //getting all files from dir
    var files = di.GetFiles();
    int count = 0;
    bool hasObject = false;
    string line = "";
    StreamWriter sw = null;
    foreach (var file in files)
    {
        using (StreamReader sr = new StreamReader(file.FullName, Encoding.GetEncoding(1250)))
        {
            while ((line = sr.ReadLine()) != null)
            {
                //when new file starts
                if (line.Contains("%%XGF NEW_SET"))
                {
                    //when new file existed I need to store old one
                    if (hasObject)
                    {
                        sw.Close();
                    }
                    else
                    {
                        //creating new file and setting exist flag
                        hasObject = true;
                        sw = new StreamWriter(string.Format("{0}/{1}-{2}", ConfigurationManager.AppSettings["OutputFilesDir"], count++, file.Name));
                        //Bill bill = new Bill();                              
                    }
                }
                else
                    //when object exists adding new lines
                    if (hasObject)
                        sw.WriteLine(line);
            }
            //when all work done saving last object
            if (hasObject)
            {
                sw.Close();
                hasObject = false;
            }
        }
    }
    sw.Dispose();
