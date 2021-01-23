        public void Test(Type desiredType, object value)
        {
            if (desiredType.IsGenericType)
            {
                if (desiredType.GetGenericTypeDefinition() == typeof(Nullable<>))
                {
                    if (value == null)
                    {
                    }
                }
            }
        }
