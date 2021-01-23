    public static T SomeMethod<T>(this object value) where T != IEnumerable
    {
      if(typeof(T).GetInterface("IEnumerable") != null)
      {
        //behaviour appropriate for IEnumerable
      }
      else
      {
        //other behaviour.
      }
    }
