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
