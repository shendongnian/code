    string[] parameters = new string[3];
    parameters[0] = arg1;
    parameters[1] = arg2;
    parameters[1] = arg3;
    
    System.Threading.Thread SendingThread = new System.Threading.Thread(Send);
    SendingThread.Start(parameters);
    
    
    public void Send(object parameters)
    {
       Array arrayParameters = new object[3];
       arrayParameters = (Array)parameters;
       string str1 = (string)arrayParameters.GetValue(0);
       string str2 = (string)arrayParameters.GetValue(1);
       string str3 = (string)arrayParameters.GetValue(2);
       ///Following code here...
    }
