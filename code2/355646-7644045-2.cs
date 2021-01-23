    static void Main()
    {
        var cnk = comb(new [] {1,2,3},2);
        foreach ( var c in cnk)
        {
        }
    }
    
    public static IEnumerable<int[]> comb(int[] a, int k)
    {
        if (a == null || a.Length == 0 || k < 1 || k > a.Length)
            yield break;
        
        int n = a.Length;	
        // 1
        if ( k == 1)
            for ( int i = 0; i < n; i++)
            {	
                yield return new int[] {a[i]};
            }
        else
            {
                // k
                for ( int i = 0; i < n - k + 1; i++)
                {			
                    for (int j = i + k - 1; j < n; j++)
                    {
                        var res = new int[k];
                        for (int t = i, c = 0; t < i + k - 1; t++, c++)					
                            res[c] = a[t];											
                        res[k-1] = a[j];					
                        yield return res;
                    }
                }
            }
    }
