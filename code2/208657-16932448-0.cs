    public static string PropertyList(this object s)
    {
      var infos = s.GetType().GetProperties();
      var sb = new StringBuilder();
      foreach (var info in infos)
      {
        sb.AppendLine(info.Name + ": " + info.GetValue(s, null));
      }
      return sb.ToString();
    }
