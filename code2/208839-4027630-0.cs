        public abstract class BaseClass
        {
            private double? cachedValue;
            public BaseClass()
            {
            }
            protected abstract double ComputeValue();
            public virtual double GetValue()
            {
                if (cachedValue.HasValue)
                {
                    return (double)cachedValue;
                }
                else
                {
                    cachedValue = ComputeValue();
                    return (double)cachedValue;
                }
            }
        }
