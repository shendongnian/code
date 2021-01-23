    public static R3Connection Connection {
            get {
                ERPConnect.LIC.SetLic( "MyLicenseKey" );
                R3Connection connection = new R3Connection( 
                            [set connection settings]
                         );
                connection.MultithreadingEnvironment = true;
                return connection;
            }
        }
