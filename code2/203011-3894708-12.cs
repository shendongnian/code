        public static void Main()
        {
            var query = db.Cars.Select<Car, Car>(c => c);
            foreach (Car aCar in query)
            {
                 Console.WriteLine(aCar.Name);
            }
        }
