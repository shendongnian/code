    StreamReader dr = new StreamReader(@"C:\txt.txt");
    string str = dr.ReadToEnd();
    string[] p = str.Split(new string[] { Environment.NewLine, " " }, StringSplitOptions.RemoveEmptyEntries);
    Dictionary<string, int> count = new Dictionary<string, int>();
    for (int i = 0; i < p.Length; i++)
    {
        try
        {
            count[p[i].Trim()] = count[p[i]] + 1;
        }
        catch
        {
            count.Add(p[i], 1);
        }
    }
