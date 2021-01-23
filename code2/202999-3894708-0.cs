        public static void Main()
        {
            var query = db.Cars.Select(c => c);
            foreach(Car aCar in query)
            {
                 Console.WriteLine(aCar.Name);
            }
        }
