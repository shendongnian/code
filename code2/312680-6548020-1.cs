    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    
    namespace TestProject
    {
        /// <summary>
        /// Summary description for myService
        /// </summary>
        [WebService(Namespace = "http://tempuri.org/")]
        [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
        [System.ComponentModel.ToolboxItem(false)]
        // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
        [System.Web.Script.Services.ScriptService]
        public class myService : System.Web.Services.WebService
        {
    
            [WebMethod]
            public string SerializeJson(Person person)
            {
                return "Success";
            }
    
            public class Person
            {
                public string firstName { get; set; }
                public string lastName { get; set; }
                public string department { get; set; }
                public Address address { get; set; }
                public string[] technologies { get; set; }
            }
    
            public class Address
            {
                public string addressline1 { get; set; }
                public string addressline2 { get; set; }
                public string city { get; set; }
                public string state { get; set; }
                public string country { get; set; }
                public string pin { get; set; }            
            }
        }
    }
