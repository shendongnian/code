    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using SAP.Middleware.Connector; // your sap connector
    
    namespace WindowsFormsSapApplication1
    {
        public class ECCDestinationConfig : IDestinationConfiguration
        {
    
            public bool ChangeEventsSupported()
            {
                return false;
            }
            public event RfcDestinationManager.ConfigurationChangeHandler ConfigurationChanged;
    
            public RfcConfigParameters GetParameters(string destinationName)
            {
    
                RfcConfigParameters parms = new RfcConfigParameters();
    
                if (destinationName.Equals("mySAPdestination"))
                {
                    parms.Add(RfcConfigParameters.AppServerHost, "sapnode.mycompany.net");
                    parms.Add(RfcConfigParameters.SystemNumber, "21");
                    parms.Add(RfcConfigParameters.SystemID, "CF1");
                    parms.Add(RfcConfigParameters.User, "mySAPuser");
                    parms.Add(RfcConfigParameters.Password, "mySAPpassword");
                    parms.Add(RfcConfigParameters.Client, "100");
                    parms.Add(RfcConfigParameters.Language, "EN"); 
                    parms.Add(RfcConfigParameters.PoolSize, "5");
                }
                return parms;
    
            }
        }
    }
