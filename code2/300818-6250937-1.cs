    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < list.Count; i++)
    {
      if (i == sb.Count - 1)
      {
        sb.Append(" and ");
      }
      else if (i > 0)
      {
        sb.Append(", ");
      }
      sb.Append(list[i])
    }
