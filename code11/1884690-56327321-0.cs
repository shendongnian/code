    var l = new List<int[]>(){
                new int[]{5,4,3},
                new int[]{5,4,3},
                new int[]{5,4,2},
                };
    
                var indexStore = new List<int>();
    
                for (int i = 0; i < l.Count - 1; i++)
                {
                    for (int x = i + 1; x < l.Count-1; x++)
                    {
                        if (l[i].SequenceEqual(l[x]))
                        {
                            indexStore.Add(x);
                        }
                    }
                }
    
                foreach (var index in indexStore)
                {
                    l.RemoveAt(index);
                }
