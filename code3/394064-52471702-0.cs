    public abstract class WithValidation<V> where V : IValidator
        {
    
            private IValidator v = Activator.CreateInstance<V>();
    
            public bool IsValid => !(Errors.Count() > 0);
    
            public IEnumerable<string> Errors
            {
                get
                {
                    var results = v.Validate(this);
    
                    List<string> err = new List<string>();
    
                    if (!results.IsValid)
                        foreach (var item in results.Errors)
                            err.Add(item.ErrorMessage);
    
                    return err;
    
                }
            }
        }
    
    public class Client : WithValidation<ClientValidator>
        {
    
            public Guid Id { get; set; }
    
            public string Name { get; set; }
    
            public int Age { get; set; }
    
        }
    
    public class ClientValidator : AbstractValidator<Client>
        {
    
            public ClientValidator()
            {
                RuleFor(c => c.Name).NotNull();
                RuleFor(c => c.Age).GreaterThan(10);
            }
    
    
        }
