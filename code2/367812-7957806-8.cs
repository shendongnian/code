    public class MyLoggingParameters
    {
      public string override ToString()
      {
        var x = GetSomeInformationFromSomewhere();
        return string.Format("MyLoggingParameters: [{0}], [{1}], [{2}]", x.Foo, x.Bar, x.Baz);
      }
    }
    var x = new MyLoggingParameters();
    logger.Info(x);
