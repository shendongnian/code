    StringBuilder sb = new StringBuilder();
    sb.AppendLine(TextBox1.Text);
    sb.AppendLine(TextBox2.Text);
    sb.AppendLine(TextBox3.Text);
    sb.AppendLine(TextBox4.Text);
    sb.AppendLine(TextBox5.Text);
    sb.AppendLine(TextBox6.Text);
    sb.AppendLine(TextBox7.Text);
    sb.AppendLine(TextBox8.Text);
    
    TextBox9.Text = HttpUtility.HtmlEncode(sb.ToString());
