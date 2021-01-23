    interface IFooData
    {
        int FooId { get; set; }
    }
    public class FooEntity
    {
        static public FooEntity FromDataTransport(IFooData data)
        {
            return new FooEntity(data.FooId, ...);
        }
    }
