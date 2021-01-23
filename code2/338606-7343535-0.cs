     protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if(value == null)
                    return ValidationResult.Success;
                var iComparableValues = ((IList)value).Cast<IComparable>().ToList();
                return AreElementsUnique(iComparableValues)
                           ? ValidationResult.Success
                           : new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
        private static bool AreElementsUnique(IList<IComparable> listOfValues)
        {
            var length = listOfValues.Count;
            for(var i = 0;i< length;i++ )
            {
                for(var j =i+1; j< length;j++)
                {
                    if(listOfValues[i].CompareTo(listOfValues[j]) ==0)
                        return false;
                }
            }
            return true;
        }
