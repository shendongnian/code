    using(var sw = new StreamWriter(path3))
    using(var sr = new StreamReader(path))
    {
        string []arrRemove = File.ReadAllLines(path2);
        HashSet<string> listRemove = new HashSet<string>(arrRemove.Count);
        foreach(string s in arrRemove)
        {
            string []sa = s.Split(',');
            if( sa.Count < 2 ) continue;
            listRemove.Add(sa[1].toUpperCase());
        }
    
        string line = sr.ReadLine();
        while( line != null )
        {
            string []sa = line.Split(',');
            if( sa.Count < 2 )
                sw.WriteLine(line);
            else if( !listRemove.contains(sa[1].toUpperCase()) )
                sw.WriteLine(line);
            line = sr.ReadLine();
        }
    }
