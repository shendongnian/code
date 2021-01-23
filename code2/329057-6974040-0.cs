        static class Program
    {
        static void Main(string[] args)
        {
            String temp = ("amanisaman");
            Console.WriteLine(temp.RemoveDupes());
            Console.ReadLine();
        }
        static String RemoveDupes(this String x)
        {
            return String.Join("", x.Distinct());
        }
    }
