         private void RichTextBoxKeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control && e.KeyCode == Keys.V)
                {
                    try
                    {
                        Clipboard.SetText(Clipboard.GetText());
                    }
                    catch (Exception)
                    {
                    }
                }
            }
