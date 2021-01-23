    public class SomeWrapperClass : DynamicObject
    {
        public event Action OnMyOtherEvent;
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            if (binder.Name == "OnMyEvent")
            {
                result = OnMyOtherEvent;
                return true;
            }
            return base.TryGetMember(binder, out result);
        }
        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            if (binder.Name == "OnMyEvent" && value is Action)
            {
                OnMyOtherEvent = (Action)value;
                return true;
            }
            return TrySetMember(binder, value);
        }
        public void Test()
        {
            if (OnMyOtherEvent != null)
                OnMyOtherEvent();
        }
        private static void TestEventHandling()
        {
            dynamic obj = new SomeWrapperClass(); // This extends DynamicObject
            obj.OnMyEvent += (Action)(() => Console.WriteLine("DO something!"));
            obj.Test();
        }
    }
