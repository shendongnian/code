    class B {
        protected string Name {get; set;}
    }
    class A: B {
        public void DoSomething(string msg) {
            Name = msg.Trim();
        }
    }
    class TestA: A {
        public string GetName() {
            return Name;
        }
    }
