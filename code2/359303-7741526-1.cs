    int curpos = 0;
            bool isReplaced = false;
            private void txt1_TextChanged(object sender, EventArgs e)
            {
                if (txt1.Text.Contains('*'))
                {
                    curpos = txt1.SelectionStart;
                    isReplaced = true;
                }
                txt1.Text = txt1.Text.Replace("*", string.Empty);
                if (isReplaced)
                {
                    txt1.Select(curpos.Equals(0) ? 0 : curpos -1, 0);
                    isReplaced = false;
                }
            }
