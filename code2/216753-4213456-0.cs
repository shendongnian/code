    public class DynamicObjectEx : DynamicObject
    {
        protected dynamic self
        {
            get
            {
                return this;
            }
        }
    }
