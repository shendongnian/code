    private Action<string, params object[]> writeToLogCallBack;
    public void WriteToLogCallBack(string s, params object[] args)
    {
      if(writeToLogCallBack!=null)
        writeToLogCallBack(s,args);
    }
