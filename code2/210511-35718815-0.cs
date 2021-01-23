    public static IEnumerable<TSource> Except<TSource, CSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> TSelector, IEnumerable<CSource> csource, Func<CSource, TKey> CSelector)
        {
            bool EqualFlag = false;
            foreach (var s in source)
            {
                EqualFlag = false;
                foreach (var c in csource)
                {
                    var svalue = TSelector(s);
                    var cvalue = CSelector(c);
                    if (svalue != null)
                    {
                        if (svalue.Equals(cvalue))
                        {
                            EqualFlag = true;
                            break;
                        }
                    }
                    else if (svalue == null && cvalue == null)
                    {
                        EqualFlag = true;
                        break;
                    }
                }
                if (EqualFlag)
                    continue;
                else
                {
                    yield return s;
                }
            }
        }
