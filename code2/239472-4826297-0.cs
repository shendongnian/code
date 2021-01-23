    public static DataSet GetTraceData(Page page)
    {
        if (page == null)
            throw new ArgumentNullException("page");
        return (DataSet)typeof(TraceContext).GetField("_requestData",
               BindingFlags.NonPublic | BindingFlags.Instance).GetValue(page.Trace);
    }
