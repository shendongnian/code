    StringBuilder sb = new StringBuilder();
    for (int i = 0; i < s.Length(); ++i)
    {
       if (i % 4 == 0) // If i is a multiple of 4
       {
          sb.append(s.Substring(i, 4)); // Append these 4
          sb.append(" "); // append a space
       }
    }
    Console.WriteLine(sb.ToString());
