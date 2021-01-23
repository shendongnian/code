    [Validator(typeof(MyViewModelValidator))]
    public class MyViewModel
    {
        public string Login { get; set; }
    }
    public class MyViewModelValidator : AbstractValidator<MyViewModel>
    {
        public MyViewModelValidator()
        {
            RuleFor(x => x.Login).NotNull().EmailAddress();
        }
    }
