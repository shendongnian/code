    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Services;
    using System.Web.Script.Serialization;
    
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [System.Web.Script.Services.ScriptService]
    [WebService(Namespace = "http://tempuri.org/")] // <-- Put something like: services.yourdomain.com in here.
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    public class WebService : System.Web.Services.WebService {
    
        [Serializable]
        protected class Record
        {
            public bool RecordExists { get; set; }
            public int ID { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Record() // Initializes default values
            {
                RecordExists = true;
                ID = 0;
                FirstName = "";
                LastName = "";
            }
        }
    
        [WebMethod]
        public string GetRecord(int id)
        {
            // Initialize the result
            Record resultRecord = new Record();
            resultRecord.RecordExists = true;
            resultRecord.ID = id;
    
            // Query database to get record...
            switch (id)
            {
                case 0:
                    resultRecord.FirstName = "John";
                    resultRecord.LastName = "Something";
                    break;
                case 1:
                    resultRecord.FirstName = "Foo";
                    resultRecord.LastName = "Foo2";
                    break;
                default:
                    resultRecord.RecordExists = false;
                    break;
            }
            
            // Serialize the result here, and return it to JavaScript.
            // The JavaScriptSerializer serializes to JSON.
            return new JavaScriptSerializer().Serialize(resultRecord);
        }
    }
