    protected override bool EvaluateIsValid()
    {
        bool isValid = base.EvaluateIsValid();
        if (isValid)
        {
            string controlToValidate = this.ControlToValidate;
            string controlValue = GetControlValidationValue(controlToValidate);
            if (!string.IsNullOrWhiteSpace(controlValue))
            {
                if (this._regEx != null && _regEx.Length > 0)
                {
                    if (Regex.IsMatch(controlValue, _regEx))
                        isValid = true;
                }
            }
        }
        
        return isValid;
    }
