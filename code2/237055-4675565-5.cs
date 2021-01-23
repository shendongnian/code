        public class Wrapper
        { 
            public int[] Nums { get { ... } } 
            public MyEnumType MyEnum { get { ... } }
        }
        ...
        public Wrapper MyMethod() 
        { 
            Wrapper wrapper = ...
            return wrapper;
        }
