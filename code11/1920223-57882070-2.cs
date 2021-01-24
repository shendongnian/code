    public static List<int> getRange(int[] T, int cible)
                {
                    var result=new List<int>();
                    var list = T.ToList();
                    if(!list.Contains(cible))
                        result.Add(-1);
                    else
                    {
                        result.Add(list.IndexOf(cible));
                        if (list.Count(x=>x==cible)>1)
                            result.Add(list.LastIndexOf(cible));
                    }
                    return result;
                }
