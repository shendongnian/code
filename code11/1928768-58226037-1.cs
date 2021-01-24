    string[] linesA = File.ReadAllLines(@"C:\file.txt");
    string[] linesB = File.ReadAllLines(@"C:\file2.txt");
    
    for (int i = 0; i < linesA.Length; i++)
    {
    	linesA[i] = linesA[i].Substring(linesA[i].IndexOf(":")+1).TrimStart();
    }
    
    for (int i = 0; i < linesB.Length; i++)
    {
    	linesB[i] = linesB[i].Substring(linesB[i].IndexOf(":")+1).TrimStart();
    }
    
    string[] result = linesA.Concat(linesB).GroupBy(x => x)
                                           .Where(g => g.Count() == 1)
                                           .Select(y => y.Key)
                                           .ToArray();
