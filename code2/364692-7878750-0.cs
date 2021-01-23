    public class CoolObject
    {
        public CoolObject()
        {
            GetObjectState = () => this.InternalState;
        }
        public Func<InternalState> GetObjectState;
    }
