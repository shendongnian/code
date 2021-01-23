    string temp = ex.InnerException.Message
                  //               ^ the error is on this dot.
    if (string.IsNullOrEmpty(temp))
    {
        ...
    }
