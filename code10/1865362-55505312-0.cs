    private void WbbHTMLeMail_PreviewKeyDown(object sender, System.Windows.Input.KeyEventArgs e)
            {
                if (e.Key == Key.Enter)
                {
                    var sText = doc.selection.createRange();
                    sText.execCommand("Paste", false, Environment.NewLine);
                    e.Handled = true;
                }
    }
