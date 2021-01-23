    public class Foo
    {
      Tuple<string, Type> SettingName = new Tuple<string, Type>("NumberOfFoos",
                                                              typeof(**TYPE**));
      public void Set(Tuple<string, Type> key, object value) 
      {
        if(value.GetType() != SettingsName.Value)
          throw new ArgumentException("value");
      }
    }
