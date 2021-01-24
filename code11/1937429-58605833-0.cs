        public double PhotoPrice()
        {
            Console.Write("Enter photo width: ");
            int width = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter photo height: ");
            int height = Convert.ToInt32(Console.ReadLine());
            if (width == 8 && height == 10)
            {
                double _price = price[0];
                return _price;
            }
            else return 0.0D;
        }
