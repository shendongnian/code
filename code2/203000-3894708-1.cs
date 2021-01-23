        private Car lambda0(Car c)
        {
            return c;
        }
        private Func<Car, Car> CachedAnonymousMethodDelegate1;
        public static void Main()
        {
            if (CachedAnonymousMethodDelegate1 == null)
                CachedAnonymousMethodDelegate1 = new Func<Car, Car>(lambda0);
            var query = db.Cars.Select(CachedAnonymousMethodDelegate1);
            foreach(Car aCar in query)
            {
                 Console.WriteLine(aCar.Name);
            }
        }
