    public interface ICar<T> where T: ICarInfo
    {
        int ID { get; set; }
        T Info { get; set; }
    }
    
    public interface ICarInfo
    {
        Motor Motor { get; set; }
        Wheels Wheels { get; set; }
        String Category{ get; set; }
    }
    public Class SUVInfo : ICarInfo
    {
        Motor Motor { get; set; } = new Motor("SUV");
        Wheels Wheels { get; set; } = new Wheels("SUV");
        String Category{ get; set; } = "SUV";
    }
    
    public Class SUV : ICar<SUVInfo>
    {
        int ID { get; set; }
        SUVInfo Info { get; set; }
    }
