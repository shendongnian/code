    public struct A
    {
        int x, y;
        double a, b;
        public A(int x, int y, double a, double b)
        {
            this.x = x;
            this.y = y;
            this.a = a;
            this.b = b;
        }
    }
    public struct B
    {
        int x, y;
        double a, b;
    }
    [StructLayout(LayoutKind.Explicit)]
    public class Union
    {
        [FieldOffset(0)]
        public A a;
        [FieldOffset(0)]
        public B b;
        public Union(A a)
        {
            this.b = default(B);
            this.a = a;            
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            A a = new A(5, 10, 0.25, 0.75);
            Union union = new Union(a);
            B b = union.b; //contains 5,10,0.25,0.75
        }
    }
