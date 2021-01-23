        List<string> marks = new List<string>();
                    marks.Add("M'00Z1");
                    marks.Add("M'0A27");
                    marks.Add("M'00Z0");
    marks.Add("0000A27");
                    marks.Add("100Z0");
    
        string[] Markings = marks.ToArray();
        
                    Array.Sort(Markings, new AlphanumComparatorFast());
