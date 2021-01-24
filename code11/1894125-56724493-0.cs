    public void CreateUsernameList(string targetfile,string outputfile)
    {
        string[] texts = File.ReadAllLines(targetfile);
        string formatted = null;
        List<string> output = new List<string>();
        foreach(string Texts in texts)
        {
            var Split = Texts.Split(new char[] { '@' });
            var Split1 = Texts.Split(new char[] { ':' });
            formatted = Split[0] + ":" + Split1[1];
            output.Add(formatted);
        }
        File.WriteAllLines(outputfile, output)
    }
