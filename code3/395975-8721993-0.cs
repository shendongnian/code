    Type t = this.ContentPlaceHolder1.Page.GetType();
    MethodInfo mi = t.GetMethod("SendSessionVariables"); 
    object[] os = new object[2]; 
    os[0] = "";
    os[1] = "";
    mi.Invoke(this.ContentPlaceHolder1.Page, os); 
