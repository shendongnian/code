    ....
    foreach(var entity in entities)
    {
            GetType()
                  .GetMethod("ValidateObj")
                  .MakeGenericMethod(entity.GetType())
                  .Invoke(this, null );
            
    }
    ....
    ....
    public void ValidateObj<TEntity>(TEntity obj) where TEntity : IValidatable {
         var errors = validatorProvider.GetValidator<TEntity>().Validate(obj);
         if (errors.Count() > 0 ) throw new ValidationException(obj, errors);
    }
