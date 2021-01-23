    public string CEF(string id, string param1 = "", string param2 = "", string param3 = "", string param4 = "") 
    { 
        MyWebservice service = new MyWebservice();
    
        //Hookup async event handler
        service.getDataStringCompleted += new 
            getDataStringCompletedEventArgs(this.getDataStringCompleted); 
        service.getDataStringAsync(id,param1, param2, param3, param4); 
        return results; // <- Isn't set yet!
    }
