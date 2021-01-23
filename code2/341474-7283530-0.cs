    public void DoFillRequest(Type type, string[] params)
    {
       MethodInfo methodInfo = this.GetType().GetMethod("FillRequest");
       MethodInfo genericMethodInfo = methodInfo.MakeGenericMethod(new Type[]{ type });
       genericMethodInfo.Invoke(this, new object[]{ params });
    }
