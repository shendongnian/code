    public string GetAllFootprints(Exception x)
    {
        var st = new StackTrace(x, true);
        var frames = st.GetFrames();
        var traceString = "";
        foreach (var frame in frames)
        {
            if (frame.GetFileLineNumber() < 1)
                continue;
            traceString +=
                "File: " + frame.GetFileName() +
                ", Method:" + frame.GetMethod().Name +
                ", LineNumber: " + frame.GetFileLineNumber();
            traceString += "  -->  ";
        }
        return traceString;
    }
