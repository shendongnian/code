    public class myModel : System.ComponentModel.IDataErrorInfo
        {
    
            private Dictionary<string, List<ValidationResult>> errors;
            private bool IsValidated = false;
    
            private void Validate()
            {
                errors = new Dictionary<string, List<ValidationResult>>();
                List<ValidationResult> lst = new List<ValidationResult>();
                Validator.TryValidateObject(this, new ValidationContext(this, null, null), lst, true);
                lst.ForEach(vr =>
                    {
                        foreach (var memberName in vr.MemberNames)
                            AddError(memberName, vr);
                    });
                IsValidated = true;
            }
            private void AddError(string memberName, ValidationResult error)
            {
                if (!errors.ContainsKey(memberName))
                    errors[memberName] = new List<ValidationResult>();
                errors[memberName].Add(error);
            }
    
            public string Error
            {
                get
                {
                    if (!IsValidated)
                        Validate();
    
                    return string.Join("\n", errors
                        .Where(kvp => kvp.Value.Any())
                        .Select(kvp => kvp.Key + " : " + string.Join(", ", kvp.Value.Select(err => err.ErrorMessage)))
                        );
                }
            }
    
            public string this[string columnName]
            {
                get
                {
                    if (!IsValidated)
                        Validate();
    
                    if (errors.ContainsKey(columnName))
                    {
                        var value = errors[columnName];
                        return string.Join(", ", value.Select(err => err.ErrorMessage));
                    }
                    else
                        return null;
                }
            }
