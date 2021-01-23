    public static void SomeMethod<T>(T argument)
    {
         if(Nullable.GetUnderlyingType(typeof(T) != null)
         {
                 /* special case for nullable code go here */
         }
         else
         {
                /* Do something else T isn't nullable */
         }
    }
