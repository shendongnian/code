    foreach (var item in ListA.Intersect(ListB, new SomeClassComparer()))
        item.IsChecked = true;
    ...
    public class SomeClassComparer : IEqualityComparer<SomeClass>
    {
        public bool Equals(SomeClass x, SomeClass y)
        {
            if (Object.ReferenceEquals(x, null) || Object.ReferenceEquals(y, null))
                 return false;
            return x.Title == y.Title;
        }
    
        public int GetHashCode(SomeClass obj)
        {
            return obj.Title.GetHashCode();
        }
    }
