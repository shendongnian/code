    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class StartsCapital : ValidationAttribute 
    {
		protected override ValidationResult IsValid(object value, ValidationContext validationContext)
			{
				var text = value as string;
				
				if(text == null)
					return ValidationResult.Success;
				
				if (text.Length > 0)
				{
					var valid = (text[0].ToString() == text[0].ToString().ToUpper());
					if (!valid)
						return new ValidationResult("Name must start with capital letter");
				}
				return ValidationResult.Success;
			}
	}
