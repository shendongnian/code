    string @namespace = "System.Windows.Forms";
    
    var items = (from t in Assembly.Load("System.Windows.Forms").GetTypes()
            where t.IsClass && t.Namespace == @namespace
            select t).ToList();
