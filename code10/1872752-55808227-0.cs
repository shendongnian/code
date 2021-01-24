    Dictionary<string,int> requests = new Dictionary<string, int>();
    string[] lines = File.ReadAllLines("somefile.txt");
    IEnumerable<string> fingerPrints = lines.Select(c => $"{c.Split(",").First()} 
    {c.Split(",").Last()}");
    foreach(string fingerPrint in fingerPrints)
    {
        if(requests.ContainsKey(fingerPrint))
        {
            requests[fingerPrint] += 1;
        }
        else
        {
            requests[fingerPrint] = 1;
        }
    }
