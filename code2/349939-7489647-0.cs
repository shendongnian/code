    class Program
    {
        
        static void Main(string[] args)
        {
            UniqueList<IntValue> list = new UniqueList<IntValue>();
            list.Add(new IntValue("Smile", 100));
            list.Add(new IntValue("Frown", 101));
            list.Add(new IntValue("Smile", 102)); // Error, key exists already
            int x = list["Smile"].Value;
            string frown = list[1].Name;
        }
    }
    public interface INamed : IEquatable<INamed>
    {
        string Name { get;}
    }
    public abstract class NamedItem : INamed
    {
        public abstract string Name { get; }
        public bool Equals(INamed other)
        {
            if(other==null) return false;           
            return Name.Equals(other.Name);
        }
    }
    public class IntValue : NamedItem
    {
        string name;
        int value;
        public IntValue(string name, int value)
        {
            this.name = name;
            this.value = value;
        }
        public override string Name { get { return name; } }
        public int Value { get { return value; } }
    }
    public class UniqueList<T> : KeyedCollection<string, T>
        where T : INamed
    {
        protected override string GetKeyForItem(T item)
        {
            return item.Name;
        }
    }
