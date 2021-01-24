    public class Person : IDynamicMetaObjectProvider {
        public int Age { get; set; }
    
        DynamicMetaObject IDynamicMetaObjectProvider.GetMetaObject(Expression parameter) {
            // Implementation omitted 
        }
    }
