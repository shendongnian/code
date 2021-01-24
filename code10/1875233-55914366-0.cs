    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Masukkan Angka : ");
            int angka = Convert.ToInt32(Console.ReadLine());
            for (int i = 1; i <= angka; i++)
            {
                Console.Write(i + ", ");
            }
            Console.Write(" hop! ");
            Console.ReadKey();
        }
    }
