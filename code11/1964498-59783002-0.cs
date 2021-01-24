       public static Result<T> OnFailure<T>(this Result<T> result, Action<Result<T>> action)
       {
            if (result.IsFailure())
            {
                action(result); // Note that result is Result<T> and action takes Result<T> as parameter
            }
    
            return result;
        }
