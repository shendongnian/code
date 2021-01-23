    class Program : MarshalByRefObject
    {
        static void Main(string[] args)
        {
            Console.Write("give number in inches : ");
            int calculating = int.Parse(Console.ReadLine());
            inches(calculating);
            Console.ReadKey();
        }
    
        private static double inches(int calculating)
        {
            Console.WriteLine(calculating + " inches = " + 2.54 * calculating + " cm");
            return 0;
        }
    }
