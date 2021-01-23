    if (asyncModel.Exception is ArgumentException)
    {
      // Handle argument exception here
      string invalidParameter = (asyncModel.Exception as ArgumentException).ParamName;
    }
    else if (...)
    {
    }
