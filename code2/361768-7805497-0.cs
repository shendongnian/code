    string [] parts = yourString.Split(',');
    StringBuilder result = new StringBuilder();
    for(int i = 0; i < parts.Length; i++)
    {
      result.Append(parts[i]);
      if(i % 3 == 0)
      {
        result.Append("<br />");
      }
    }
