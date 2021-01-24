        public class One
        {
            public int A { get; set; }
        }
        public class Two
        {
            public string S { get; set; }
        }
        public class T
        {
            public One One { get; set; }
            public Two Two { get; set; }
        }
        public class OrderComparer : IComparer<Two>
        {
            public int Compare(Two x, Two y)
            {
                if (((x == null) || (x.S == null)) && ((y == null) || (y.S == null)))
                    return 0;
                if ((x == null) || (x.S == null))
                    return -1;
                if ((y == null) || (y.S == null))
                    return 1;
                return x.S.CompareTo(y.S);
            }
        }
        static void Main(string[] args)
        {
            var collection = new List<T> {
                new T{ One = new One{A=1}, Two = new Two{ S="dd" } },
                new T{ One = new One{A=5}, Two = null },
                new T{ One = new One{A=0}, Two = new Two{ S=null } },
                new T{ One = new One{A=6}, Two = new Two{ S="aa" } },
            };
            var comparer = new OrderComparer();
            collection = collection.OrderBy(e => e.Two, comparer).ToList();
        }
But in your case you have to write `` var collection = query.AsEnumerable().OrderBy(x=>x.Address)``.
Also there is other method:
var result = query.Where(x=>x.Address==null || x.Address.Municipality==null)
.Union(query.Where(x.Address!=null && x.Address.Municipality!=null).OrderBy(x=>x.Address.Municipality));
