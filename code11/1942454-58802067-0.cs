    string cstring = System.Configuration.ConfigurationManager.ConnectionStrings["SampleLogicAppState"].ConnectionString;
         ConnectionMultiplexer LogicAppStatusConnection = ConnectionMultiplexer.Connect(cstring);
         
         System.Net.Http.Headers.HttpRequestHeaders reqHeaders = req.Headers;
         string LogicApp = reqHeaders.Contains("LogicApp") ? reqHeaders.GetValues("LogicApp").First() : null;
         string ID = reqHeaders.Contains("ID") ? reqHeaders.GetValues("ID").First() : null;
         string Status = reqHeaders.Contains("Status") ? reqHeaders.GetValues("Status").First() : null;
     
        string cacheKey = LogicApp + "+" + ID;
         IDatabase LogicAppStatusCache = LogicAppStatusConnection.GetDatabase();
 
