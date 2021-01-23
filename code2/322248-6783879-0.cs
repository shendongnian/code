    public interface IClass { int Value{get;set;} }
        public class ExampleImpl : IClass
        {
            int Value{get;set;}
            /* Additional Members\methods here */
        }
        public class HelperClass
        {
        public static int GenMethod<T>(T item) where T:IClass
        {
            return item.Value * 2 + 1;
        }
        }
