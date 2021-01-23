    public class Class1
    {
        public static string GetTestData()
        {
            if (System.Configuration.ConfigurationSettings.AppSettings["TestData"] != null)
            {
                return System.Configuration.ConfigurationSettings.AppSettings["TestData"];
            }
            return null;
        }
    }
