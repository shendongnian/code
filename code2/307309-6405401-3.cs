       public class SomeObject
        {
            public string ID { get; set; }
        }
    
        public class SomeObjectComparer : IEqualityComparer<SomeObject>
        {
            public bool Equals(SomeObject x, SomeObject y)
            {
                return x.ID == y.ID;
            }
    
            public int GetHashCode(SomeObject obj)
            {
                return obj.ID.GetHashCode();
            }
        }
    
        class Program
        {
            static void Main(string[] args)
            {
                List<SomeObject> l1, l2;
                // lists init ...
    
                IEqualityComparer<SomeObject> comparer = new SomeObjectComparer();
    
                List<SomeObject> l3 = l2.Except(l1, comparer).ToList();
    
            }
        }
