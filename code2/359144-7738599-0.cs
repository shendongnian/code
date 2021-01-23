    var comparer = new MyClassEqualityComparer();
    Console.WriteLine(comparer.Equals(object1, object2));
    // ...
    public class MyClassEqualityComparer : EqualityComparer<MyClass>
    {
        private static readonly string[] _names = { "_id", "_personName" };
        private static readonly FieldInfo[] _infos =
            typeof(MyClass).GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                           .Where(f => _names.Contains(f.Name))
                           .ToArray();
        
        public override bool Equals(MyClass x, MyClass y)
        {
            return _infos.All(f => object.Equals(f.GetValue(x), f.GetValue(y)));
        }
        public override int GetHashCode(MyClass obj)
        {
            return _infos.Aggregate(31, (h, f) =>
                {
                    object o = f.GetValue(obj);
                    unchecked
                    {
                        return (h + ((o == null) ? 0 : o.GetHashCode())) * 17;
                    }
                });
            }
        }
    }
