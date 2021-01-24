    public static IEnumerable<string> Kmers(int k, string x)
            {
                for (int i = 0; i < x.Length - k + 1; i++)
                    yield return x.Substring(i, k);
            }
    
    var result = Kmers(3, "GCATACGAT").ToArray(); 
