    public abstract class Animal
    {
        public abstract void OutputInterestingFact();
    }
    
    public class Cat : Animal {
        private string _purrStrength = "Teeth Shattering";
        public string PurrStrength {
            get { return _purrStrength; }
            set { _purrStrength = value; }
        }
        public override void OutputInterestingFact()
        {
            Console.WriteLine(PurrStrength);
        }
    }
    
    public class Dog : Animal {
        public override void OutputInterestingFact()
        {
            // Do stuff for dog here
        }
    }
    
    public class Horse : Animal {
        public override void OutputInterestingFact()
        {
            // Do stuff for horse here
        }
    }
