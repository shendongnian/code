    private void CopyButton_Click(object sender, RoutedEventArgs e)
    {
        List<string> stringList = GetTextAsStringList();
        StringBuilder sb = new StringBuilder();
        foreach (string s in stringList)
        {
            sb.Append(s);
            sb.Append("\r\n");
        }
                
        Clipboard.SetData(System.Windows.DataFormats.Text, sb.ToString());
    
        FormattedDisplayTextBox.Clear();
        FormattedDisplayTextBox.Text = sb.ToString();
    }
    
    private List<string> GetTextAsStringList()
    {
        List<string> stringList = new List<string>();
        int pos = 0;
        string inputText = InputTextBox.Text;
    
        CustomTextSource store = new CustomTextSource();
        store.Text = inputText;
        store.FontRendering = new FontRendering(InputTextBox.FontSize,
                                                InputTextBox.TextAlignment,
                                                null,
                                                InputTextBox.Foreground,
                                                new Typeface(InputTextBox.FontFamily,
                                                    InputTextBox.FontStyle,
                                                    InputTextBox.FontWeight,
                                                    InputTextBox.FontStretch));
    
        using (TextFormatter formatter = TextFormatter.Create())
        {
            while (pos < store.Text.Length)
            {
                using (TextLine line = formatter.FormatLine(store,
                                        pos,
                                        InputTextBox.ViewportWidth,
                                        new GenericTextParagraphProperties(
                                            store.FontRendering),
                                        null))
                {
                    stringList.Add(inputText.Substring(pos, line.Length - 1));
                    pos += line.Length;
                }
            }
        }
    
        return stringList;
    }
