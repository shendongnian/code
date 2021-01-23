    static void Main(string[] args)
    {
        const string InputString = "Item X $4.50 Description of item \r\n\r\n Item Z $4.75";
        var r = new Regex(@"[0-9]+\.[0-9]+");
        var mc = r.Matches(InputString);
        var matches = new Match[mc.Count];
        mc.CopyTo(matches, 0);
        var myFloats = new float[matches.Length];
        var ndx = 0;
        foreach (Match m in matches)
        {
            myFloats[ndx] = float.Parse(m.Value);
            ndx++;
        }
        foreach (float f in myFloats)
            Console.WriteLine(f.ToString());
        // myFloats should now have all your floating point values
    }
