    Dictionary<string,string>  dict;
    public void Init(){
        dict = new Dictionary<string,string>();
        dict["India"] = "www.mysite.in";
        dict["France"] = "www.mysite.fr";
    }
    public string GetPage(string country){
        string result = dict["Default"];
        if(dict.ContainsKey(theKey)){
            result  = dict[theKey];
        }
        return result;
    }
