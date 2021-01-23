    public sealed class ComplexObject
    {
        public int PropA { get; private set; }
        public string PropB { get; private set; }
    
        public sealed class Builder
        {
            int _propA;
            string _propB;
            
            public Builder SetPropA(int propA)
            {
                // validate
                _propA = propA;
                return this;
            }
            
            public Builder SetPropB(string propB)
            {
                // validate
                _propB = propB;
                return this;
            }
            
            public CustomObject ToCustomObject()
            {
                return new CustomObject
                {
                    PropA = _propA,
                    PropB = _propB
                };
            }
        }
    }
