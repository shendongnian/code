        private static IEnumerable<A> Intersect(A[] alist, B[] blist)
        {
            Array.Sort(alist);
            Array.Sort(blist);
            for (int i = 0, j = 0; i < alist.Length && j < blist.Length;)
            {
                if (alist[i].Value == blist[j].Value)
                {
                    yield return alist[i];
                    i++;
                    j++;
                }
                else
                {
                    if (alist[i].Value < blist[j].Value)
                    {
                        i++;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }
