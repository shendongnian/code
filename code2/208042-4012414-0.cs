    public interface IBusinessObjectValidator
    {
      void AddRule(BusinessRule rule);
    
      void Validate(IBusinessObject target, ValidationResults results);
    }
    Public class BusinessObject: IBusinessObjectValidator
    {
    ...
    
      public void Validate(IBusinssObject target, ValidationResults results)
      {
          foreach (var rule in this.businessRules)
          {
              if (!rule.Validate(target))
              {
                 results.AddResult(new ValidationResult(rule.ErrorMessage, target, rule.Key, rule.Tag, null));
              }
          }
      }
    }
