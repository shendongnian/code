    public class TestClass<T>
    {
        public TestClass()
        {
            bool hasStruct = false;
            Type t1 = this.GetType().GetGenericArguments()[0];
            if(t1.IsValueType){
                hasStruct = true;
            }
            if (t1.IsGenericType)
            {
                Type t = t1.GetGenericArguments()[0];
                if (t.IsValueType)
                {
                    hasStruct = true;
                }
            }
        
        }
    }
