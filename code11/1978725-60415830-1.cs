    public class Model
    {
        public string Id { get; set; }
    }
    
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
        }
    }
    
    public interface IService
    {
        void Run(Model model);
    }
    
    public class Service : IService
    {
        private readonly IValidator<Model> _validator;
    
        public Service(IValidator<Model> validator)
        {
            _validator = validator;
        }
    
        public void Run(Model model)
        {
            if (!_validator.Validate(model).IsValid)
                throw new ArgumentException(nameof(model));
    
            Console.WriteLine(model.Id);
        }
    }
    
    public static void Main(string[] args)
    {
        var serviceProvider = new ServiceCollection()
            .AddSingleton<IService, Service>()
            .AddSingleton<IValidator<Model>, ModelValidator>()
            .BuildServiceProvider();
    
        var service = serviceProvider.GetService<IService>();
        service.Run(new Model { Id = "1"});
        service.Run(new Model { Id = "" });
    }
