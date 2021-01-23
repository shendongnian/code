    interface IHaveDistanceLengthAndHeight
    {
        DistanceType Distance { get; }
        DistanceType Height   { get; }
        DistanceType Length   { get; }
    }
    
    class Building : IHaveDistanceLengthAndHeight
    {
        ...
