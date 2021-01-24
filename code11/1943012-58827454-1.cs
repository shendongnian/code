    public class SomeOtherChange : IChange
    {
        public int AParameter {get;set;}
        public string AnotherParameter {get;set;}
        public DateTime TimeStamp {get;set;}
        public void GetAndCallHandler(Container container)
        {
            var handler = container.GetInstance<SomeOtherChangeHandler>();
            handler.Handle(this);
        }
    }
