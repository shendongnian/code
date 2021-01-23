    using System;
    
    public abstract class Beverage
    {
        public Beverage()
        {
            Description = "Unknown Beverage";
        }
        
        private string description;
        
        public virtual string Description
        {
            get { return description; }
            set { description = value; }
        }
    }
    
    public class Espresso : Beverage
    {
        public Espresso()
        {
            Description = "Espresso";
        }
    }
    
    public class Mocha : Beverage
    {
        private readonly Beverage beverage;
    
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        
        public override string Description
        {
            get { return beverage.Description + ", Mocha"; }
            set { /* Ignored */ }
        }
    }
    
    public class Test
    {
        static void Main()
        {
            Beverage espresso = new Espresso();
            Beverage mocha = new Mocha(espresso);
            Console.WriteLine(mocha.Description); // Prints Espresso, Mocha
        }
    }
