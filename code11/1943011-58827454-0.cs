    interface IChange
    {
        IChangeHandler GetHandler(Container container);
    }
    public class SomeOtherChange : IChange
    {
        public int AParameter {get;set;}
        public string AnotherParameter {get;set;}
        public DateTime TimeStamp {get;set;}
        public IChangeHandler GetHandler(Container container) => container.GetInstance<SomeOtherChangeHandler>();
    }
