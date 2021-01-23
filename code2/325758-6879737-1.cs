    public class WhatClass
    {
        public WhatClass()
        {
            int theCount = Count; // This will set theCount to 0 because int is a value type
            AProperty = new SomeOtherClass; // This is fine because the setter is totally usable
            SomeOtherClass thisProperty = AProperty; // This is completely acceptable because you just gave AProperty a value;
            thisProperty = AnotherProperty; // Sets thisProperty to null because you didn't first set the "AnotherProperty" to have a value
        }
    
        public int Count { get; set; }
        public SomeOtherClass AProperty { get; set; }
        public SomeOtherClass AnotherProperty { get; set; }
    }
