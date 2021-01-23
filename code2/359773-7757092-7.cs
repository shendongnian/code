    public class Files
    {
        public string FileName { get; private set; }
        public string CreationDate { get; private set; }
        public List<Files> theseFiles
        {
            get
            {
                return GetFiles();
            }
        }
        public Files(string fileName, string creationDate)
        {
            this.FileName = fileName;
            this.CreationDate = creationDate;
        }
        public static List<Files> GetFiles()
        {
            //Gets full file names
            List<String> t = Directory.GetFiles(@"C:\Users\justin\Desktop\New folder (2)\").ToList();
            List<String> t2 = new List<string>();
            foreach (var yyy in t)
            {
                t2.Add(Path.GetFileName(yyy));
            }
            //Creation Dates
            var dirInfo = new DirectoryInfo(@"C:\Users\justin\Desktop\New folder (2)");
            List<String> fct = (from f in dirInfo.GetFiles("*", SearchOption.TopDirectoryOnly)
                                select f.CreationTime.Date.ToShortDateString()).ToList();
            List<String> y = new List<string>();
            foreach (var zzz in fct)
            {
                y.Add(zzz);
            }
            //Creats a collection of the file objects for you to use
            List<Files> gg = new List<Files>();
            
            
            for (int x = 0; x < t2.Count(); x++)
            {
                //Adjusts the dates to add 0's in the off chance that they aren't there
                if(DateTime.Parse(y[x]).Month < 10)
                {
                    y[x] = "0" + y[x];
                }
                if(DateTime.Parse(y[x]).Day < 10)
                {
                    y[x] = y[x].Insert(3, "0");
                }
                Files thefile = new Files(t2[x].ToString(), y[x].ToString());
                gg.Add(thefile);
                
            }
            return gg;
        }
        public override string ToString()
        {
            return string.Format("{0} , {1}", FileName, this.CreationDate);
        }
    }
