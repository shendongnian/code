    interface IFactory<T> where T: BaseCar
    {
        T GetCar();
    }
    
    class MyFactory : IFactory<MyCar>
    {
        MyCar GetCar()
        {
        }
    }
    
    
    class MyCar : BaseCar
    {
    }
