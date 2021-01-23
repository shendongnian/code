    class MyClass : IValidatableObject
    {
       public string EId {get;set;}
       public string PId {get;set;}
    
       public IEnumerable<ValidationResult> Validate(ValidationContext vC)
       {
          if (string.IsNullOrEmpty(EId) && string.IsNullOrEmpty(PId))
             yield return new ValidationResult("one of EId or PId must be set!", new []{ "EId", "PId" });
       }
    
    }
