    class Base {
    
        protected virtual void SayHi() {
            Console.WriteLine("Base says hi!");
        }
    
    }
    
    class Derived : Base {
    
        protected override void SayHi() {
            Console.WriteLine("Derived says hi!");
        }
    
        public void DoIt() {
            base.SayHi();
            this.SayHi();
        }
    }
