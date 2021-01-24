    public interface IBase
    {
        void Init(object obj);
    }
    public class SubA : IBase
    {
        public SubA(int a)
        {
            Init(a);
        }
        public void Init(object obj)
        {
            int a = (int)obj;
            // do stuff
        }
    }
    public class SubB : IBase
    {
        public SubB(string s)
        {
            Init(s);
        }
        public void Init(object obj)
        {
            string s = (string)obj;
            // do stuff
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IBase> stuff = new List<IBase>()
            {
                new SubA(65),
                new SubB("B")
            };
        }
    }
