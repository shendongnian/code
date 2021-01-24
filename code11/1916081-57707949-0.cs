    public class TheBase
    {
        public int One { get; set; }
        public int Two { get; set; }
        public int Three { get; set; }
        public TheBase(int one, int two, int three)
        {
            One = one;
            Two = two;
            Three = three;
        }
        public TheBase(TheBase theBase)
        {
            One = theBase.One;
            Two = theBase.Two;
            Three = theBase.Three;
        }
    }
    public class Derived : TheBase
    {
        public int Four { get; set; }
        public int Five { get; set; }
        public Derived(TheBase theBase, int four, int five) : base(theBase)
        {
            Four = four;
            Five = five;
        }
        public Derived(int one, int two, int three, int four, int five) : base(one, two, three)
        {
            Four = four;
            Five = five;
        }
    }
