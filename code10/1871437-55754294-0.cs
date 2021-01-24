    foreach (var type in types)
    {
      var callsShow = false;
      foreach (var method in type.GetMethods(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
      {
        var byteArray = method.GetMethodBody()?.GetILAsByteArray();
        if (byteArray == null)
        {
          continue;
        }
        var bytes = BitConverter.ToString(byteArray);
        var isMatch = Regex.IsMatch(bytes, "14-.*-28-.*-00-2B-26");
        callsShow = callsShow || isMatch;
      }
      if (!callsShow)
      {
        MightBeBad(type);
      }
    }
