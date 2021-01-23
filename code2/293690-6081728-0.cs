    StringBuilder sb = new StringBuilder();
    for(int i = 0; i < parts.Length - 4; i++)
    {
      sb.FormatAppend("{0}-", parts[i]);
    }
    sb.Length = sb.Length - 1; // remove trailing -
