    public static string GetDebugString(this Exception ex)
    {
       var builder = new StringBuilder();
       GetDebugString(ex, builder);
       while ((ex = ex.InnerException) != null)
       {
          GetDebugString(ex, builder);
       }
       return builder.ToString();
    }
    private static void GetDebugString(Exception ex, StringBuilder builder)
    {
		builder.AppendLine(ex.GetType().Name);
		builder.AppendLine();
		builder.AppendLine(ex.Message);
		builder.AppendLine();
		builder.AppendLine(ex.StackTrace);
		builder.AppendLine();
    }
    [OperationContract]
    public void Foo()
    {
        this.MakeSafeCall(() => this.UnsafeFoo());
    }
    public void Unsafe()
    {
        // do stuff
    }
    private void MakeSafeCall(Action action)
    {
        try
        {
           action();
        }
        catch (Exception ex)
        {
           throw new FaultException(ex.GetDebugString());
        }
    }
