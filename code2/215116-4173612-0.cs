    class Base { public abstract void Method(); }
    class Child {
        public override void Method() {
            Console.WriteLine("Child.Method");
        }
    }
    Action<Base> magicalAction = // defined somehow
    magicalAction(new Child()); // aiya!
