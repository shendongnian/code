        public rates(bool dummy) //Note that dummy is not used in this function.  It just distinguishes rates() from rates(bool)
        {
            Console.Write("Enter dollar limit: ");              
            Limit = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the low rate: ");
            LowRate = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter the high rate: ");
            HighRate = Convert.ToDouble(Console.ReadLine());
        }
