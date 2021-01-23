    using ImpromptuInterface;
    using ImpromptuInterface.Dynamic;
    public class StaticDynamicWrapper:ImpromptuForwarder{
        public StaticDynamicWrapper(Type target):base(InvokeContext.CreateStatic(target)){
        }
    }
