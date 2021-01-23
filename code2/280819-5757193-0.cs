    private void richTextBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
            {
                if (richTextBox1.SelectionColor != Color.Red)
                {
                    richTextBox1.SelectionColor = Color.Red;
                }
                if (e.KeyCode == Keys.Enter)
                {
                    richTextBox1.SelectionColor = Color.Blue;
                }
            }
