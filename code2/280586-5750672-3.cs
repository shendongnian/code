    static class Program
    {
        static void Main(string[] args)
        {
            DoIt((byte) 0);
        }
        static void DoIt(object value)
        {
            Entity e = new Entity();
            e.Value = (int)value;
        }
    }
    public class Entity
    {
        public int Value { get; set; }
    }
