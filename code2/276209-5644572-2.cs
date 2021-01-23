    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < s.Length; i += 4)
    {
          sb.append(s.Substring(i, 4)); // Append these 4
          if (i != s.Length - 4)
              sb.append(" "); // append a space for all but the last group
    }
    Console.WriteLine(sb.ToString());
