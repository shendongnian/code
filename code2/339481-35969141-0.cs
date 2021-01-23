        private void Txt_Search_Box_TT_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
            FOFO:
                int start =
                    RtfAll_Messages.Find(Txt_Search_Box_TT.Text, RtfAll_Messages.SelectionStart + 1,
                    RichTextBoxFinds.None);
                if (start >= 0)
                    RtfAll_Messages.Select(start, Txt_Search_Box_TT.Text.Length);
                else
                {
                    start = 0;
                    RtfAll_Messages.SelectionStart = 0;
                    RtfAll_Messages.SelectionLength = 0;
                    goto FOFO;
                }
            }
        }
