    private Dictionary<string, string> GetData(string intext)
    {
        Dictionary<string, string> keylist = new Dictionary<string, string>();
        string[] keywords = intext.Split(' ');
        foreach (string s in keywords)
        {
            if (s.Contains("addkey") && s.Contains("def"))
            {
                string fkey = key1.Replace("_", " ");
                string fdef = def2.Replace("_", " ");
                keylist.Add(fkey, fdef);
                say("Phrase '" + fkey + "' added with response '" + fdef + "'");
                say("Your Dictionary contains " + keylist.Count.ToString() + " word(s).");
            }
        }
        return keylist;
    }
