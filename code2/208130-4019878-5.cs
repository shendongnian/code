    foreach(var entity in entities)
    {
            var validator = validatorProvider.GetType().GetMethod("GetValidator").MakeGenericMethod(entity.GetType()).Invoke(validatorProvider, null );
            var errors = validator.Validate(entity);
            if (errors.Count() > 0)
            {
                throw new Exception("A validation error");
            }
    }
 
