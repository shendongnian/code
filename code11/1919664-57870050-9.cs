    class ViewModel
    {
        public List<Car> ListOfCars { get; set; }
        public Car SelectedCar { get; set; }
        public List<Type> TypeLists { get; set; }
        public ViewModel()
        {
            // Add five cars
            ListOfCars = new List<Car>();
            for (int i = 0; i < 5; i++)
            {
                ListOfCars.Add(new Car());
            }
            // Add three types: type0, type1, type2
            TypeLists = new List<Type>();
            for (int i = 0; i < 3; i++)
            {
                TypeLists.Add(new Type() { Name = $"type{i}", IDType = i });
            }
        }
    }
