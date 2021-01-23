    foreach (var q in query)
    {
         if (sb.Length != 0)
             sb.Append(';');
         sb.Append(q.Destination); // instead of sb.Append("ID");
         sb.Append(':');
         sb.Append(q.Destination);
    }
