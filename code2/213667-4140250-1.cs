    class B 
    {
        public virtual void Frob(Giraffe g)
        {
        }
    }
    class D : B
    {
        public override void Frob(Animal a)
        {
        }
    }
    ....
    B b = new D();
    b.Frob(new Giraffe());  // Calls D.Frob, which takes any animal.
