    class Program
    {
        static void Main(string[] args)
        {
            IMapper mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<object, UserViewModel>().ConvertUsing<UserViewModelConverter>();
            }).CreateMapper();
            UserViewModel viewModelFromOne = mapper.Map<UserViewModel>(new SourceOne { Foo = "One" });
            UserViewModel viewModelFromTwo = mapper.Map<UserViewModel>(new SourceTwo { Foo = "Two" });
            Console.WriteLine($"Foo from One {viewModelFromOne.Foo}");
            Console.WriteLine($"Foo from Two {viewModelFromTwo.Foo}");
            Console.ReadLine();
        }
    }
    public class UserViewModelConverter : ITypeConverter<object, UserViewModel>
    {
        private static readonly UserViewModel _instance = new UserViewModel
        {
            Foo = "StaticValue"
        };
        public UserViewModel Convert(object source, UserViewModel destination, ResolutionContext context)
        {
            return _instance;
        }
    }
    public class SourceOne
    {
        public string Foo { get; set; }
    }
    public class SourceTwo
    {
        public string Foo { get; set; }
    }
    public class UserViewModel
    {
        public UserViewModel()
        {
            Console.WriteLine("Instantiating UserViewModel...");
        }
        public string Foo { get; set; }
    }
