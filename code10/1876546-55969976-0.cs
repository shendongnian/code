        public class Rootobject
        {
            public string Type { get; set; }
            public Parameter[] parameters { get; set; }
        }
        public class Parameter
        {
            public A A { get; set; }
            public B B { get; set; }
            public C C { get; set; }
            public D D { get; set; }
            public E E { get; set; }
            public F F { get; set; }
        }
        public class A
        {
            public string type { get; set; }
            public string defaultValue { get; set; }
        }
        public class B
        {
            public string type { get; set; }
            public string defaultValue { get; set; }
        }
        public class C
        {
            public string type { get; set; }
            public string defaultValue { get; set; }
        }
        public class D
        {
            public string type { get; set; }
            public string defaultValue { get; set; }
        }
        public class E
        {
            public string type { get; set; }
            public string defaultValue { get; set; }
        }
        public class F
        {
            public string type { get; set; }
            public string[] dropDownItems { get; set; }
            public string defaultValue { get; set; }
        }
