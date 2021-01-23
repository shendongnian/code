    class Program
    {
        static void Main(string[] args)
        {
            int add;
            try
            {
                ArrayList al = new ArrayList();
            t:
                Console.Write("Enter the Number of elements do you want to insert in arraylist");
                int n = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter the Values:");
                for (int i = 0; i < n; i++)
                {
                    al.Add(Console.ReadLine());
                }
                foreach (var a in al)
                {
                    Console.WriteLine("valus:" + a);
                }
                Console.WriteLine("Add another number yes:1 ");
                add = Convert.ToInt32(Console.ReadLine());
                while (add == 1)
                {
                    goto t;
                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Enter the Valid Number and try again");
            }
            Console.ReadKey();
        }
    }
}
