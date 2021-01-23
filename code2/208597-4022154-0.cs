    public class YourBaseClass { // perhaps abstract
        public int SomeParentValue {get;set;}
        public void SomeParentMethod() {Console.WriteLine(SomeParentValue);}
    }
    public class A : YourBaseClass {
        public string SomeValueA {get;set;}
    }
    public class B : YourBaseClass {
        public DateTime SomeValueB {get;set;}
    }
    public class C : A {
        public bool SomeValueC {get;set;}
    }
