    private void Text_SelectionChanged(object sender, System.Windows.RoutedEventArgs e)
            {
                TextBox tb = sender as TextBox;
                if (tb != null && !String.IsNullOrEmpty(TypedText) && tb.SelectionStart != TypedText.Length)
                {
                    tb.SelectionStart = TypedText.Length;
                    tb.SelectionLength = 0;
                }
            }
