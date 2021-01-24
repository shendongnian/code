    public abstract class BaseClass
    {
        public int a;
        public int b;
        public int c;
        public abstract BaseClass Clone();
    }
    public class DerivedClass : BaseClass
    {
        public int new1;
        public int new2;
        public override BaseClass Clone()
        {
            return this.MemberwiseClone() as BaseClass;
        }
        public override string ToString()
        {
            return string.Format("{0}{1}{2}{3}{4}", a, b, c, new1, new2);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            DerivedClass AClass = new DerivedClass();
            AClass.a = 1;
            AClass.b = 2;
            AClass.c = 3;
            DerivedClass BClass = AClass.Clone() as DerivedClass;
            BClass.new1 = 4;
            BClass.new2 = 5;
            Console.WriteLine(BClass.ToString());
        }
    }
