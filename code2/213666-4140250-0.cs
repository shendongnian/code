    class B 
    {
        public virtual void Frob(Animal a)
        {
        }
    }
    class D : B
    {
        public override void Frob(Giraffe g)
        {
        }
    }
    ....
    B b = new D();
    b.Frob(new Tiger());  // Calls D.Frob, which takes a giraffe.
