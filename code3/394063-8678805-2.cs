    public abstract class Entity<T> where T : Entity<T>
    {
        public Boolean IsValid(IValidator<T> validator)
        {
            // var context  = new ValidationContext(this);
            // var instance = context.InstanceToValidate as T;
            // return validator.Validate(instance).IsValid;
            
            return validator.Validate(this as T).IsValid;
        }
    }
    public class Rambo : Entity<Rambo>
    {
        public Int32 MadnessRatio { get; set; }
        public Boolean CanHarmEverything { get; set; }
    }	
    public class RamboValidator : AbstractValidator<Rambo>
    {
        public RamboValidator()
        {
            RuleFor(r => r.MadnessRatio).GreaterThan(100);
        }
    }
	
    class Program
    {
        public static void Main(String[] args)
        {
            var ramboInstance = new Rambo {
                MadnessRatio = 90
            };			
        
            Console.WriteLine("Is Rembo still mad?");
            Console.WriteLine(ramboInstance.IsValid(new RamboValidator()));
   			
            Console.ReadKey();
        }
    }
