    StringBuilder sb = new StringBuilder();
    var isFirst = true;
    foreach(var x in myDict) 
    {
      if (isFirst) 
      {
        sb.Append($"{x.Key}={x.Value}");
        isFirst = false;
      }
      else
        sb.Append($";{x.Key}={x.Value}"); 
    }
    string myDesiredOutput = sb.ToString(); 
