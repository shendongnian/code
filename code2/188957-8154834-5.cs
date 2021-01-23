    [WebMethod]
    [ScriptMethod(UseHttpGet = true, ResponseFormat = ResponseFormat.Json)]
    public String GetServerTime()
    {
      return Execute(() => DateTime.Now.ToString());
    }
    public T Execute<T>(Func<T> action)
    {
      if (action == null)
        throw new ArgumentNullException("action");
      try
      {
        return action.Invoke();
      }
      catch (Exception ex)
      {
        throw; // Do meaningful error handling/logging...
      }
    }
