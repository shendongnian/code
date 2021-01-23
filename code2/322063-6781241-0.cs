    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Configuration;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace WCFRESTService100 
    { 
        public class myclass 
        { 
            string conn1 = ConfigurationManager.ConnectionStrings["myconn"].ToString(); 
            string SQLstr = "myStoredProc1"; 
    
            public void SomeMethod()
            {
                SqlConnection conn = new SqlConnection(SDconn);
                SqlCommand cmd = new SqlCommand(SQLstr, conn); 
    
    
            }
        } 
    }
