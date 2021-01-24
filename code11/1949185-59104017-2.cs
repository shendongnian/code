    // Let's show arbitrary many lines (whe only 2?)
    // Let's accept all types (not necessary strings)
    public static void ShowMessageLines(param object[] lines) {
      // public method - input arguments validation
      if (null == lines)
        throw new ArgumentNullException(nameof(lines));
      // Combine all lines into textToShow
      // First line must have a prefix - "your message was " 
      string textToShow = string.Join(Environment.NewLine, lines
        .Select((text, index) => index == 0 
           ? $"your message was {text}"
           :   text?.ToString()));
      MessageBox.Show(textToShow);
    }
    ...
    private void Btn_Display_Click(object sender, RoutedEventArgs e) {
      ShowMessageLines(
         TextBox_Msg.Text, 
         DateTime.Now.ToString("dd/MM/yyyy"));
    }
