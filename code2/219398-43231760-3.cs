    public string GetAllFootprints(Exception x)
    {
            var st = new StackTrace(x, true);
            var frames = st.GetFrames();
            var traceString = new StringBuilder();
            foreach (var frame in frames)
            {
                if (frame.GetFileLineNumber() < 1)
                    continue;
                traceString.Append("File: " + frame.GetFileName());
                traceString.Append(", Method:" + frame.GetMethod().Name);
                traceString.Append(", LineNumber: " + frame.GetFileLineNumber());
                traceString.Append("  -->  ");
            }
            return traceString.ToString();
    }
