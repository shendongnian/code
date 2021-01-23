       public class Animal
    {
        public virtual String talk() { return "Hi"; }
        public string sing() { return "lalala"; }
    }
    public class Cat : Animal
    {
        public override String talk() { return "Meow!"; }
    }
    public class Dog : Animal
    {
        public override String  talk() { return "Woof!"; }
        public new string sing() { return "woofa woofa woooof"; }
    }
    public class CSharpExampleTestBecauseYouAskedForIt
    {
        public CSharpExampleTestBecauseYouAskedForIt()
        {
            write(new Cat());
            write(new Dog());
        }
        public void write(Animal a) {
            System.Diagnostics.Debug.WriteLine(a.talk());
	    }
    }
