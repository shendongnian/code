    var sb = new StringBuilder();
    using(var reader = cmd.ExecuteReader()) {
      while(reader.Read()) {
        sb.Append("ColoumA: ").Append(reader.GetInt32(0))
          .Append(", Coloum B").Append(reader.GetInt32(1))
          .Append(", ").Append(reader.GetString(2)).AppendLine();
      }
    }
    string s  = sb.ToString();
