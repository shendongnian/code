    public class Program
    {
        enum MyEnum
        {
            First = 10,
            Middle,
            Last = 1
        }
        public static void Main(string[] args)
        {
            for (int i = (int)MyEnum.First; i <= (int)MyEnum.Last; i++)
            {
                Console.WriteLine(i); // will never happen
            }
            Console.ReadLine();
        }
    }
