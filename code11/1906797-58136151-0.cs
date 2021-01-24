        private static void UpdateAttribute()
        {
            var serverName = ConfigurationManager.AppSettings["ServerName"];
            var databaseName = ConfigurationManager.AppSettings["DatabaseName"];
            var cubeName = ConfigurationManager.AppSettings["CubeName"];
            var dimensionName = ConfigurationManager.AppSettings["DimensionName"];
            var attributeName = ConfigurationManager.AppSettings["AttributeName"];
            //Server
            var server = new Server();
            server.Connect(serverName);
            //Database
            var db = server.Databases.FindByName(databaseName);
            //Cube
            var cube = db.Cubes.FindByName(cubeName);
            //dim
            var dim = db.Dimensions.FindByName(dimensionName);
            //attribute
            var attribute = dim.Attributes.FindByName(attributeName);
            var newAttributeName = $"{attribute.Name}_New";
            attribute.Name = newAttributeName;
            //this will update the dimension in the Server
            dim.Update();
            
            
        }
