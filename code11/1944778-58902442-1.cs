    string mynamespace = "FantasticBeasts";
    
    var q = from t in Assembly.GetExecutingAssembly().GetTypes()
            where t.IsClass && t.Namespace == mynamespace
            select t;
