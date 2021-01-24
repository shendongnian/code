    public class EnvData
    {
        public EnvData()
        {
            { 
                defaultEmail = "test@gmail.com";
                defaultPassword = "MyPass123";
            }
            if(ConfigurationManager.AppSettings["Env"] == "Test")
            {
                empName = "John Smith";
                EmployeeID = "1234";
                Company = "McDonalds";
                Designation = "McManager";
               
            }
            else if (ConfigurationManager.AppSettings["Env"] == "Dev")
            {
                empName = "Joe Smith";
                EmployeeID = "3456";
                Company = "McDonalds";
                Designation = "FryGuy";
               
            }
        }
          public static string defaultEmail;
          public static string defaultPassword;
          public static string empName;
          public static string EmployeeID;  //can be an int
          public static string Company;
          public static string Designation;
      }
    }
