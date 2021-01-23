    var builder = new StringBuilder();
    for (int i = 0; i < split.Length; i++)
    {
      builder.Append(split[i]);
      builder.Append('\n');   
    }
    richTextBox2.Text = builder.ToString();
