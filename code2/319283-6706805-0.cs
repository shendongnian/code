    interface ICar
    {
        void Configure();
    }
    
    class TT77Car : ICar
    {
        public void Configure()
        {
        ConfigClasses.Add(
                        item.Key,
                        new CarsTT(item.Value, item.Value, "", "start"));
    
        }
    }
    
    ...
    
    class D8797 : ICar
    {
        public void Configure()
        {
        ConfigClasses.Add(
                        item.Key,
                        new Carsd8080(null, new List<string[]>()));
        }
    }
    
    
    //And this is how to use it
    ICar car = //resolve to the car item: new Car(), via IoC or whatever
    car.Configure();
