    using System;
    static class CompareTuple {
        public static bool Compare<T1, T2, T3>(this Tuple<T1, T2, T3> value, T1 v1, T2 v2, T3 v3) {
            return value.Item1.Equals(v1) && value.Item2.Equals(v2) && value.Item3.Equals(v3); 
        }
    }
    class Program {
        static void Main(string[] args) {
            var t = new Tuple<int, int, bool>(1, 2, false);
            if (t.Compare(1, 1, false)) {
                // 1st case
            } else if (t.Compare(1, 2, false)) {
                // 2nd case
            } else { 
                // default
            }
        }
    }
