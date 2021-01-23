    static string MultiReplace(string this CSV, string Orig, string Replacement)
    {
        string final = "";
        foreach (string s in CSV.Split(','))
        {
            final += s.Replace(Orig, Replacement);
        }
        return final;
    }
