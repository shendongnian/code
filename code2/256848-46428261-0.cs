     protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
            {
                bool baseResult = base.ProcessCmdKey(ref msg, keyData);
                //if key is tab and TextBox1 is focused then jump to TextBox2
                if (keyData == Keys.Tab && TextBox1.Focused)
                {
                    TextBox2.Focus();
                    return true;
                }
                else if (keyData == Keys.Tab && TexBox2.Focused)
                {
                    TextBox3.Focus();
                    return true;
                }
                    return baseResult;
            }
