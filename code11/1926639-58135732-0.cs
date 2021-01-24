      var pat = @"\d+[\)]";
        var str=  "1) Step to start workorder 1 2)step 2 continue 3)issue of workorder40)create workorder by name";
        var rgx = new Regex(pat);
        var output = new List<string>();
        var matches = rgx.Matches(str);
        for(int i=0;i<matches.Count-1;i++)
        {
            output.Add(str.Substring(matches[i].Index, matches[i+1].Index- matches[i].Index));
            Console.WriteLine(str.Substring(matches[i].Index, matches[i + 1].Index - matches[i].Index));
        }
        output.Add(str.Substring(matches[matches.Count - 1].Index));
        Console.WriteLine(str.Substring(matches[matches.Count - 1].Index));
