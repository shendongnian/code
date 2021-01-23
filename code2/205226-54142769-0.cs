    peopleList2.Except(peopleList1, new FuncEqualityComparer<Person>((p, q) => p.ID == q.ID));
    public class FuncEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> comparer;
        private readonly Func<T, int> hash;
       
        public FuncEqualityComparer(Func<T, T, bool> comparer)
        {
          this.comparer = comparer;
          if (typeof(T).GetMethod(nameof(object.GetHashCode)).DeclaringType == typeof(object))
              hash = (_) => 0;
          else
              hash = t => t.GetHashCode(); 
        }
       
        public bool Equals(T x, T y) => comparer(x, y);
        public int GetHashCode(T obj) => hash(obj);
    }
