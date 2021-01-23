    public static partial class FooRules
    {
      public static ValidationResult FooIDUnique(Foo foo, ValidationContext context)
      {
        bool check = false;
        
        using (FooEntities fe = new FooEntities())
        { 
          check = fe.Foo.Any(f => f.FooId == foo.fooId); 
        }
        if (!check)
          return ValidationResult.Success;
                
        return new ValidationResult("FooID error msg,", new string[] { "FooID" });
      }
    }
