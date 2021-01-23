namespace ConsoleApplication1
{
    public delegate void Transformer(ref int x);
    class Test
    {
        public static void Transform(int[] values, Transformer t)
        {
            for (int i = 0; i &lt; values.Length; i++)
            {
                t(ref values[i]);
            }
        }
       static void Square(ref int x)
       {
           x = x * x;
       }
       static void Minus(ref int x)
       {
           x = x - 1;
       }
        static void Main()
        {
            int[] values = { 1, 2, 3 };
            Transformer t = Test.Minus;
            t += Test.Square;
            Test.Transform(values, t);
            foreach (int i in values)
            {
                Console.Write(i + " ");
            }
        }
    }
}
