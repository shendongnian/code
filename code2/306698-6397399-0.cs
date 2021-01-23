    class Sprocket: Product {}
    class Gadget : Product {}
    class GadgetFactory : IFactory<Gadget> 
    { 
        public List<Gadget> MakeStuff() 
        { 
            return new List<Gadget>() { new Gadget(); } 
        }
    }
    ... later ...
    IFactory<Gadget> gf = new GadgetFactory();
    IFactory<Product> pf = gf; // Covariant!
    List<Product> pl = pf.MakeStuff(); // Actually a list of gadgets
    pl.Add(new Sprocket());
