    class B
    {
        public virtual Animal Animal{ get; set;}
    }
    class D : B
    {
        public override Tiger Animal { ... }
    }
    B b = new D();
    b.Animal = new Giraffe();
