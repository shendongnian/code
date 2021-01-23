    public static class WinFormsExtensions
    {
       public static void AppendLine(this TextBox source, string value)
       {
          if (source.Text.Length==0)
             source.Text = value;
          else
             source.AppendText("\r\n"+source);
       }
    }
