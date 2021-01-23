    // Warning Air Code - Subject to bonehead mistakes
    
    internal sealed class SomeDict : Dictionary<myKeyType, myObjectType>
    {
        public new void Add(myKeyType key, myObjectType value)
        {
            this.Add(value);
        }
    
        internal void Add(myObjectType value)
        {
            base.Add(value.Id, value);
        }
    
    }
