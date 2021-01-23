    static void Main(string[] args)
    {
        TextReader tr = new StreamReader(@"C:\Test\new.txt");
        String SplitBy = "----------------------------------------";
        String fullLog = tr.ReadToEnd();
        String[] sections = fullLog.Split(new string[] { SplitBy }, StringSplitOptions.None);
        foreach (String r in sections)
        {
            string Lines = r.Split('\n');
            foreach(string line in Lines)
            {
                if(line.Trim().Length.Equals(0))
                     ...; // line empty
            }
        }
    }
