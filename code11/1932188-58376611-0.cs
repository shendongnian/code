    public class MyClass {
    
        private readonly MyClassOptions options;
        
        public MyClass(MyClassOptions options) {
            this.options = options;
        }
    
        public void SomeMethod() {
            string name = options.Name;
            string city = options.City;
    
            //...
        }
    
        //...
    }
