    public static Type GetCompilerType<T>(this T object)
    {
      return typeof (T);
    }
    
    int? x = 5;
    Console.WriteLine(x.GetCompilerType());
