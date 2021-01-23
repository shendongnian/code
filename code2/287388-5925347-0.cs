    public interface IStr { }
    public struct St1 : IStr
    {
        public static int ID = 1;
    }
    public struct St2 : IStr
    {
        public static int ID = 2;
    }
    public class StructFactory : System.Collections.ObjectModel.KeyedCollection<int, IStr>
    {
        public static StructFactory Default = new StructFactory();
        protected override int GetKeyForItem(IStr item)
        {
            FieldInfo finfo = item.GetType().GetField("ID", 
                BindingFlags.Static | BindingFlags.Public);
            return (int)finfo.GetValue(item);
        }
        public StructFactory()
        {
            Add(new St1());
            Add(new St2());
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            St1 x = (St1)StructFactory.Default[1];
            St2 y = (St2)StructFactory.Default[2];
        }
    }
