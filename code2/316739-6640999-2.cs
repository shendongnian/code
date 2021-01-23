    using MyResources;
    namespace LocalizationDemo
    {
       class Program
       {
          static void Main(string[] args)
          {
             System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo("de-DE");
             Console.WriteLine(Resources.GetString(StrId.Street));
          }
       }
    }
