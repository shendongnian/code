    StringBuilder sb = new StringBuilder();
    foreach (string s in txtStatus.Lines) {
      if (s.Length > 0) {
        sb.AppendLine(s.Substring(1));
      }
    }
    txtStatus.Text = sb.ToString();
