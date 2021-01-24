    class CarManager
    {
        public CarManager(IDatabaseClient databaseClient)
        {
            _databaseClient = databaseClient;
        }
    
        public async Task AddCarAsync(string model, int productionYear)
        {
            var car = new Car(model, productionYear);
    
            _databaseClient.AddDataAsync("cars", car);
        }
    
        private readonly IDatabaseClient _databaseClient;
    }
