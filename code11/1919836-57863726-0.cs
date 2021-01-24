    public interface IManufacturerRepository
    {
        List<IManufacturer> GetManufacturers();
    }
    public interface IManufacturer
    {
        String        Name         { get; }
        IPhoneFactory PhoneFactory { get; } // <-- this is the abstract factory
    }
