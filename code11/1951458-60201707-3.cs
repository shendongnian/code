    public class MyModelValidator : AbstractValidator<MyModel>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public MyModelValidator(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            RuleFor(myModel => myModel.Id)
                .NotEmpty();
            RuleFor(myModel => myModel.Value)
                .Must(value => MyRule(value, _httpContextAccessor.HttpContext.Request.Method));
        }
        private bool MyRule(string value, string method)
        {
            if (method.ToUpper() == "POST")
            {
                return true;
            }
            else if (method.ToUpper() == "PUT")
            {
                // validatation logic for value
                return !string.IsNullOrWhiteSpace(value);
            }
            return false;
        }
    }
