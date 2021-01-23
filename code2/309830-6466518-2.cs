    public class ClassWithDefaultParameters {
        public string Msg { get; set; }
        public ClassWithDefaultParameters(string msg = "Hello World") {
            Msg = msg;
        }
    }
    public class ClassWithConstructorOverloads {
        public string Msg { get; set; }
        public ClassWithConstructorOverloads(string msg) {
            Msg = msg;
        }
        public ClassWithConstructorOverloads() : this("Hello World") {}
    }
