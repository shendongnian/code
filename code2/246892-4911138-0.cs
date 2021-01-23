    class Base {
        public event EventHandler Bang;
    
        protected virtual void OnBang ()
        {
            if (Bang != null)
                Bang (this, EventArgs.Empty);
        }    
    }
    
    class Derived : Base {
        public void DoSomething ()
        {
            // let's bang for some fun
            OnBang (); // will raise Bang
        }
    
        protected override void OnBang ()
        {
            Console.WriteLine ("It's gonna bang now!");
            base.OnBang (); // if we remove this line, event will not be fired
        }
    }
