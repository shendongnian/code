    public class MyClass : MyBaseClass {
        public MyClass() : this(0) { }
        public MyClass(int id) : base(id) { }
    }
    public class MyBaseClass {
        public MyBaseClass(int id) {
            this.id = id;
        }
    }
