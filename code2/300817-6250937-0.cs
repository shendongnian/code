    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < list.Count; i++)
    {
      if (i > 0)
      {
        if (i == sb.Count - 1)
        {
          sb.Append(" and ");
        }
        else 
        {
          sb.Append(", ");
        }
      }
      sb.Append(list[i])
    }
