    interface IFactory
    {
        BaseCar GetCar();
    }
    class MyFactory : IFactory
    {
        BaseCar IFactory.GetCar()
        {
            return GetCar();
        }
        MyCar GetCar()
        {
        }
    }
