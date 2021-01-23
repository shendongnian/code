    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    ublic class CustomValidationAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var model = value as MyViewModel;
            if (model == null)
            {
                return false;
            }
            if (model.WireTransfer == 1)
            {
                return !string.IsNullOrEmpty(model.FirstName) &&
                       !string.IsNullOrEmpty(model.LastName);
            }
            else if (model.WireTransfer == 2)
            {
                return !string.IsNullOrEmpty(model.PaypalEmail);
            }
            return false;
        }
    }
