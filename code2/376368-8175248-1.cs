    public static class Size
    {
        public int Of(int x)
        {
            return sizeof(int);
        }
        public int Of(long x)
        {
            return sizeof(long);
        }
        public unsafe int Of(MyStruct x)
        {
            //only works if MyStruct is unmanaged
            return sizeof(MyStruct);
        }
    }
    public class Program
    {
        public void Main()
        {
            int x = 0;
            Console.WriteLine(Size.Of(x));
        }
        public void OldMain()
        {
            long x = 0;
            Console.WriteLine(Size.Of(x));
        }
    }
