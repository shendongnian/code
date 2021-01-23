        static Random random = new Random();
        static void Main(string[] args)
        {
            int vouchersToGenerate = 10;
            int lengthOfVoucher = 10; 
            List<string> generatedVouchers = new List<string>();
            char[] keys = "ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890".ToCharArray();
            Console.WriteLine("Vouchers: ");
            while(generatedVouchers.Count < vouchersToGenerate)
            {
                var voucher = GenerateVoucher(keys, lengthOfVoucher); 
                if (!generatedVouchers.Contains(voucher))
                {
                    generatedVouchers.Add(voucher);
                    Console.WriteLine("\t[#{0}] {1}", generatedVouchers.Count, voucher);
                }
            }
            Console.WriteLine("done");
            Console.ReadLine();
        }
        private static string GenerateVoucher(char[] keys, int lengthOfVoucher)
        {
            return Enumerable
                .Range(1, lengthOfVoucher) // for(i.. ) 
                .Select(k => keys[random.Next(0, keys.Length - 1)])  // generate a new random char 
                .Aggregate("", (e, c) => e + c); // join into a string
        }
  
