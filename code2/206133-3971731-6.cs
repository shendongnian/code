    MyHeader mySoapHeader = new MyHeader();
  
    // Populate the values of the SOAP header.
    mySoapHeader.Username = Username;
    mySoapHeader.Password = SecurelyStoredPassword;
    // Create a new instance of the proxy class.
    MyWebService proxy = new MyWebService();
  
    // Add the MyHeader SOAP header to the SOAP request.
    proxy.MyHeaderValue = mySoapHeader;
    // Call the method on the proxy class that communicates with
    // your Web service method.
    string results = proxy.MyWebMethod();
