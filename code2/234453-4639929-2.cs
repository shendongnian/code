    public bool Equals(T value)
    {
       // uses Reflection to check if a Type-specific `Equals` exists...
       var specificEquals = typeof(T).GetMethod("Equals", new Type[] { typeof(T) });
       if (specificEquals != null &&
           specificEquals.ReturnType == typeof(bool))
       {
           return (bool)specificEquals.Invoke(this.Value, new object[]{value});
       }
       return this.Value.Equals(value);
    }
