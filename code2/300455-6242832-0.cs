    class Base {
        public virtual void M<T>() where T : Control { ... }
    }
    class Derived: Base {
        public override void M<T>() where T : Button { ... }
    }
    Base b = new Derived();
    b.M<TextBox>();    //That's not a Button!
