    ...
    private new string GetControlValidationValue(string id)
    {
        var control = this.NamingContainer.FindControl(id); 
        if (control != null)
        {
            if (control is HiddenField) 
            {
                return Page.Request.Form[((HiddenField)control).UniqueID];
            } 
            else 
            {
                return base.GetControlValidationValue(id);
            }
        }
    }
    protected override bool EvaluateIsValid()
    {   
        // removed 'base.' from the call to 'GetControlValidationValue'
        string controlValidationValue = GetControlValidationValue(base.ControlToValidate);
        if (controlValidationValue.Trim().Length == 0)
        {
            return true;
        }
        bool flag = (base.Type == ValidationDataType.Date) && !this.DetermineRenderUplevel();
        if (flag && !base.IsInStandardDateFormat(controlValidationValue))
        {
            controlValidationValue = base.ConvertToShortDateString(controlValidationValue);
        }
        bool cultureInvariantRightText = false;
        string date = string.Empty;
        if (this.ControlToCompare.Length > 0)
        {
            //same as above
            date = GetControlValidationValue(this.ControlToCompare);
            if (flag && !base.IsInStandardDateFormat(date))
            {
                date = base.ConvertToShortDateString(date);
            }
        }
        else
        {
            date = this.ValueToCompare;
            cultureInvariantRightText = base.CultureInvariantValues;
        }
        return BaseCompareValidator.Compare(controlValidationValue, false, date, cultureInvariantRightText, this.Operator, base.Type);
    }
            
    ...    
