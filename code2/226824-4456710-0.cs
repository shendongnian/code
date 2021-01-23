    public class c2 {
        public string prop1 { get; set; }
        private readonly c1 _obj1;
    
        public c2() {
            prop1 = "hello";
            _obj1 = new c1();
        }
        public c1 PropObj1 { get { return _obj1; } }
    }
