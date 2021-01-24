    public interface IBase
    {
        void Init();
    }
    public class SubA : IBase
    {
        private int _a;
        public SubA(int a)
        {
            _a = a;
        }
        public void Init()
        {
            // do stuff with _a
        }
    }
    public class SubB : IBase
    {
        private string _s;
        public SubB(string s)
        {
            _s = s;
        }
        public void Init()
        {
            // do stuff with _s
        }
    }
    public class SubC : IBase
    {
        private int _a;
        private string _s;
        public SubC(int a, string s)
        {
            _a = a;
            _s = s;
        }
        public void Init()
        {
            // do stuff with _a and _s
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<IBase> stuff = new List<IBase>()
            {
                new SubA(65),
                new SubB("B"),
                new SubC(100, "Z"),
            };
            foreach (IBase sub in stuff)
            {
                sub.Init();
            }
        }
    }
