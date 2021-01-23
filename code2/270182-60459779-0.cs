    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace NS
    {
    public static class DataReunion
    {
        public static List<Tuple<T1, T2>> FullJoin<T1, T2, TKey>(List<T1> List1, Func<T1, TKey> KeyFunc1, List<T2> List2, Func<T2, TKey> KeyFunc2)
        {
            List<Tuple<T1, T2>> result = new List<Tuple<T1, T2>>();
            Tuple<TKey, T1>[] identifiedList1 = List1.Select(_ => Tuple.Create(KeyFunc1(_), _)).OrderBy(_ => _.Item1).ToArray();
            Tuple<TKey, T2>[] identifiedList2 = List2.Select(_ => Tuple.Create(KeyFunc2(_), _)).OrderBy(_ => _.Item1).ToArray();
            identifiedList1.Where(_ => !identifiedList2.Select(__ => __.Item1).Contains(_.Item1)).ToList().ForEach(_ => {
                result.Add(Tuple.Create<T1, T2>(_.Item2, default(T2)));
            });
            result.AddRange(
                identifiedList1.Join(identifiedList2, left => left.Item1, right => right.Item1, (left, right) => Tuple.Create<T1, T2>(left.Item2, right.Item2)).ToList()
            );
            identifiedList2.Where(_ => !identifiedList1.Select(__ => __.Item1).Contains(_.Item1)).ToList().ForEach(_ => {
                result.Add(Tuple.Create<T1, T2>(default(T1), _.Item2));
            });
            return result;
        }
    }
    }
