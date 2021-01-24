    public static class Validator
    {
       public static void Validate<T>(Expression<Func<string, T>> f)
       {
          var name = (f.Body as MemberExpression).Member.Name;
          if(f.Compile().Invoke(name) == null)
             throw new ArgumentNullException(name);    
       }
    }
