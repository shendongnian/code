    var comparer = new MyClassEqualityComparer();
    Console.WriteLine(comparer.Equals(object1, object2));
    // ...
    public class MyClassEqualityComparer : EqualityComparer<MyClass>
    {
        private static readonly string[] _names = { "_id", "_personName" };
        private static readonly FieldInfo[] _infos =
            typeof(MyClass).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                           .Where(fi => _names.Contains(fi.Name))
                           .ToArray();
        
        public override bool Equals(MyClass x, MyClass y)
        {
            return _infos.All(fi => object.Equals(fi.GetValue(x), fi.GetValue(y)));
        }
        public override int GetHashCode(MyClass obj)
        {
            unchecked
            {
                int hash = 31;
                foreach (FieldInfo fi in _infos)
                {
                    object val = fi.GetValue(obj);
                    hash = (hash * 17) + ((val == null) ? 0 : val.GetHashCode());
                }
                return hash;
            }
        }
    }
