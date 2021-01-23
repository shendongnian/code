     //calling my query config
     QueryConfigurationSection wconfig = (QueryConfigurationSection)ConfigurationManager.GetSection("MyConfiguration/MyQuery");
    string _query1 = wconfig.Query1.Value;
    string _query2 = wconfig.Query2.Value; 
 
