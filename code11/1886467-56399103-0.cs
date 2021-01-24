          protected void CheckAttributes(T model)
          {
               var context = new ValidationContext(model, null, null);
               var results = new List<ValidationResult>();
               var isValid = Validator.TryValidateObject(model, context, results, true);
               if (!isValid)
               {
                    foreach (var validationResult in results)
                    {
                         foreach (var memberName in validationResult.MemberNames)
                         {
                              AddError(memberName, validationResult.ErrorMessage);
                         }
                    }
               }
          }
