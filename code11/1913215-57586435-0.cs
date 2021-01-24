    // Change This 
    string fields = line.Split(ConfigurationManager.AppSettings["splitcode"].ToString());
    //To This
    
    string s = ConfigurationManager.AppSettings["splitcode"].ToString();
    char sperator = Convert.ToChar(s);
    string[] fields = line.Split(sperator);
