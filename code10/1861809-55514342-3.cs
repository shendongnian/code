    //Model class
    [Required]
    [CustomValidation(typeof(CustomValidation), "ValidateBirthday")]
    public string Birthday
    {
        get => _birthday;
        set => Set(ref _birthday, value);
    }
    //Custom Validation Class
    public static ValidationResult ValidateBirthday(object inObj, ValidationContext inContext)
    {
         Model model = (Model) inContext.ObjectInstance;
         string text = model.Birthday;
         DateTime birthday = text.ToDate();
         if (birthday == default)
         {
             return new ValidationResult("Birthday is not valid", new List<string> {"Birthday"});
         }
         // Future
         if (birthday >= DateTime.Now.Date)
         {
             return new ValidationResult("Birthday is in the future", new List<string> {"Birthday"});
         }
         // Past
         return birthday <= DateTime.Now.Date.AddYears(-200)
             ? new ValidationResult("Birthday too old", new List<string> {"Birthday"})
             : ValidationResult.Success;
     }
