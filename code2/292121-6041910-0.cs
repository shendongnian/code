    class Program
    {
        static void Main(string[] args)
        {
            string text = "8$154#3$021308831#7$NAME SURNAME#11$2166220160#10$5383237309#52$05408166#";
            string[] values = text.Split('$', '#');
            for (var i = 0; i < values.Length - 1; i = i + 2)
            {
                Console.WriteLine("Between " + values[i] + "$ and # -> My data is " + values[i+1]);
            }
            Console.ReadLine();
        }
    }
