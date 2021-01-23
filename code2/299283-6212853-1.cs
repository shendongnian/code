    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    
    public static class DatabaseConnection
    {
    private readonly string _thisConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;
    
        static DataClassesDataContext datacontext;    
        public static DataClassesDataContext getConnection()
        {
           datacontext = new DataClassesDataContext(_thisConnectionString);
            return datacontext;
        }
    }
