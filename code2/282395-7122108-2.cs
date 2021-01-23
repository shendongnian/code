    [MyCustomServerValidation(ErrorMessage = MyCustomValidationMessage)]
    public class MyCustomViewModel
    {
        private const string MyCustomValidationMessage = "user error!";
        [Display(Name = "Email Address")]
        [MyCustomClientValidation(ErrorMessage = MyCustomValidationMessage)]
        public string Value { get; set; }
        [HiddenInput(DisplayValue = false)]
        public string DependentProperty1 { get; set; }
    }
