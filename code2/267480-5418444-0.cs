    catch (Exception ex)
    {
        var st = new StackTrace(ex, true); // create the stack trace
        var query = st.GetFrames()         // get the frames
                      .Select(frame => new
                       {                   // get the info
                           FileName = frame.GetFileName(),
                           LineNumber = frame.GetFileLineNumber(),
                           ColumnNumber = frame.GetFileColumnNumber(),
                           Method = frame.GetMethod(),
                           Class = frame.GetMethod().DeclaringType,
                       });
        // log the information obtained from the query
    }
