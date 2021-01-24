    public static T GetMaxValue<T>() where T : Enum {
      return (T)(Enum.GetValues(typeof(T)).Cast<T>().Max());
    }
    ...
    SomeEnum max = GetMaxValue<SomeEnum>();
