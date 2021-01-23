    interface IFoo
    {
        int Age { get; }
        string Name { get; }
    }
    class Foo : IFoo
    {
        public int Age { get; set; }
        public string Name { get; set; }
    }
    abstract class ValidatorBase<T>
    {
        public class Rule    
        {
            public Func<T, bool> Test { get; set; }
            public string Message { get; set; }
        }
        protected abstract IEnumerable<Rule> Rules { get; }
        public IEnumerable<string> Validate(T t)
        {
            return this.Rules.Where(r => !r.Test(t)).Select(r => r.Message);
        }
    }
    class FooValidator : ValidatorBase<IFoo>
    {
        protected override IEnumerable<ValidatorBase<IFoo>.Rule> Rules
        {
            get
            {
                return new Rule[] {
                    new Rule { Test = new Func<IFoo,bool>(foo => foo.Age >= 0), Message = "Age must be greater than zero" },
                    new Rule { Test = new Func<IFoo,bool>(foo => !string.IsNullOrEmpty(foo.Name)), Message = "Name must be provided" }
                };                    
            }
        }
    }
    
    static void Main(string[] args)
    {
        var foos = new[] {
            new Foo { Name = "Ben", Age = 30 },
            new Foo { Age = -1 },
            new Foo { Name = "Dorian Grey", Age = -140 }
        };
        var fooValidator = new FooValidator();
        foreach (var foo in foos)
        {
            var messages = fooValidator.Validate(foo);
            if (!messages.Any()) Console.WriteLine("Valid");
            else foreach (var message in messages) Console.WriteLine("Invalid: " + message);
            Console.WriteLine();
        }
    }
