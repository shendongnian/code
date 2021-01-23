    class Program
     {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string to find its lenght");
            string ch = Console.ReadLine();
            Program p = new Program();
            int answer = p.run(ch);
            Console.WriteLine(answer);
            Console.ReadKey();
        }
        public int run(string ch)
        {
            int count = 0;
            foreach (char c in ch)
            {
                count++;
            }
            return count;
        }
    }
