    private void xBox_KeyDown(object sender, KeyEventArgs e)
    {
         TextRange tr = new TextRange(xBox.Document.ContentStart ,
                                        xBox.Document.ContentEnd);
         if (tr.Text.Length >= 4000 || e.Key == Key.Space || e.Key == Key.Enter)
         {
               e.Handled = true;
               return;
         }
    }
