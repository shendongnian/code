    public class A_B : I_A_B {
        [Import]
        public IFooA A {get; set;}
        
        [Import]
        public IFooB B {get; set;}
        public string SayFooA() => A.SayFooA();
        public string SayFooB() => B.SayFooB();
    ...
