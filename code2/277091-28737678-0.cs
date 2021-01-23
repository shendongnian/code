    public static IEnumerable<T> Like<T>(this IEnumerable<T> lista, Func<T, string> type, string pattern)
                {
        
                    int[] pf = prefixFunction(pattern);
        
                    foreach (T e in lista)
                    {
                        if (patternKMP(pattern, type(e), pf))
                            yield return e;
                    }
        
                }
        
                private static int[] prefixFunction(string p)
                {
        
        
                    int[] pf = new int[p.Length];
                    int k = pf[0] = -1;
        
        
                    for (int i = 1; i < p.Length; i++)
                    {
                        while (k > -1 && p[k + 1] != p[i])
                            k = pf[k];
        
                        pf[i] = (p[k + 1] == p[i]) ? ++k : k;
                    }
                    return pf;
        
                }
        
                private static bool patternKMP(string p, string t, int[] pf)
                {
        
                    for (int i = 0, k = -1; i < t.Length; i++)
                    {
        
                        while (k > -1 && p[k + 1] != t[i])
                            k = pf[k];
        
                        if (p[k + 1] == t[i])
                            k++;
        
                        if (k == p.Length - 1)
                            return true;    
                    }
        
                    return false;
        
                }
