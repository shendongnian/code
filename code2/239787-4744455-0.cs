            private void richTextBox1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.Control == true && e.KeyCode == Keys.V)
                {
                    e.Handled = true;
                    string st = Clipboard.GetText();
                    richTextBox1.Text = st;
                }
            }
