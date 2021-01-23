    Type t = this.ContentPlaceHolder1.Page.GetType();
    MethodInfo mi = t.GetMethod("SendSessionVariables" ， BindingFlags.Instance | BindingFlags.NonPublic);  // Add BindingFlags.Instance | BindingFlags.NonPublic to access private method.
    object[] os = new object[2]; 
    os[0] = "";
    os[1] = "";
    mi.Invoke(this.ContentPlaceHolder1.Page, os); 
