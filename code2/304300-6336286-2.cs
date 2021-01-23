    public interface IObjectWithSector
    {
        Sector Sector { get; }
    }
    internal interface IObjectWithSectorSetter: IObjectWithSector
    {
        void SetSector(Sector sector);
    }
