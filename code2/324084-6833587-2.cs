    string[] Lines = richTextBox.Text.Split(new char[] {'\r','\n'});
    StringBuilder sb = new StringBuilder();
    double d = double.Parse(textBox1.Text);
    for(int i = 0; i < Lines.Lenght; ++i)
         sb.AppendLine((double.Parse(Lines[i]) + d).ToString());
    richTextBox.Text = sb.ToString();
