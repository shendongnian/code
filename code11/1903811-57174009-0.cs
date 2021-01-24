    public class MyType
    {
        [ContractAnnotation("throwOnNull:true => notnull")]
        public static Type GetType(string name, bool throwOnNull)
        {
            return null;
        }
    }
