    public Class SUV : ICar
    {
        int ID { get; set; }
        ICarInfo Info { get; set; } = new CarInfo(new Motor("SUV"), new Wheels("SUV"), "SUV");
    }
