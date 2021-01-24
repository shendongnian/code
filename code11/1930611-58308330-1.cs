    public void Backlight(MatchCollection matchCollection, String Clr)
            {    
                foreach (Match m in matchCollection)
                {
                    codeRichTextBox.SelectionStart = m.Index;
                    codeRichTextBox.SelectionLength = m.Length;
                    ColorConverter conv = new ColorConverter();
                    Color color = (Color)conv.ConvertFromString(Clr);
                    codeRichTextBox.SelectionColor = color;
                    // codeRichTextBox.SelectionColor = Color.Brown;
                    // codeRichTextBox.SelectionColor = Color.FromArgb(255, 100, 10, 16);
                    // codeRichTextBox.SelectionColor = Color.FromArgb(color);
                }
            }
