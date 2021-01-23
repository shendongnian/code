        static void Main(string[] args)
        {
            string StartingPath = "c:\\";
            List<string> mydirs = new List<string>(); // will contains folders not containing "-"
            foreach (string d in Directory.GetDirectories(StartingPath))
            {                               
                if (!(d.Contains("_")))
                {
                    mydirs.Add(d);
                }                
                foreach (string dir in mydirs)
                {
                    Console.WriteLine(dir);
                }
            }
        }
    }
