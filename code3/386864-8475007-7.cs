    public static T Multiply(T n1,T n2)
    {
      if(typeof(T)==typeof(int))
        return (T)(object)((int)(object)n1*(int)(object)n2);
      ...
      return _multiply(n1, n2);
    }
