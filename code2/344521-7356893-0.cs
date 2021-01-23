    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("BaseEnum, should print (A,B,C):");
            foreach (BaseEnum e in BaseEnum.Values)
            {
                Console.WriteLine(e.Name);
            }
            Console.WriteLine("BaseEnum in ChildEnum, should print (A,B,C,D,E):");
            foreach (BaseEnum e in ChildEnum.Values)
            {
                Console.WriteLine(e.Name);
            }
            Console.WriteLine("ChildEnum in ChildEnum, should print (D,E):");
            foreach (ChildEnum e in ChildEnum.Values.Where(d => d.GetType() == typeof(ChildEnum)))
            {
                Console.WriteLine(e.Name);
            }
        }
    }
    public class BaseEnum
    {
        public static readonly BaseEnum A = new BaseEnum("A");
        public static readonly BaseEnum B = new BaseEnum("B");
        public static readonly BaseEnum C = new BaseEnum("C");
        public static IEnumerable<BaseEnum> Values
        {
            get
            {
                yield return A;
                yield return B;
                yield return C;
            }
        }
        public readonly String Name;
        protected BaseEnum(String name)
        {
            this.Name = name;
        }
    }
    public class ChildEnum : BaseEnum
    {
        public static readonly ChildEnum D = new ChildEnum("D");
        public static readonly ChildEnum E = new ChildEnum("E");
        new public static IEnumerable<BaseEnum> Values
        {
            get
            {
                foreach (var baseEnum in BaseEnum.Values)
                    yield return baseEnum;
                yield return D;
                yield return E;
            }
        }
        public ChildEnum(string name)
            : base(name)
        {
        }
    } 
