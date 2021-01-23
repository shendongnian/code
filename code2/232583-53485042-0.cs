    public void  ShortCut(object sender, KeyEventArgs e, TextBox  box   )
        {
            string s, tmp1, tmp2;
            int selectionIndex;
            switch (e.KeyCode)
            {
                case Keys.V: // paste 
                    if (Clipboard.ContainsText())
                    {
                        s = Clipboard.GetText(TextDataFormat.Text);
                        selectionIndex = box.SelectionStart;
                        tmp1 = box.Text.Substring(0, selectionIndex);
                        tmp2 = box.Text.Substring(selectionIndex + box.SelectionLength);
                        box.Text = tmp1 + s + tmp2;
                    }
                    break;
                case Keys.C: // copy 
                    if (box.SelectionLength > 0)
                    {
                        selectionIndex = box.SelectionStart;
                        s = box.Text.Substring(selectionIndex, box.SelectionLength);
                        Clipboard.SetText(s);
                    }
                    break;
                case Keys.X: // cut 
                    if (box.SelectionLength > 0)
                    {
                        selectionIndex = box.SelectionStart;
                        s = box.Text.Substring(selectionIndex, box.SelectionLength);
                        Clipboard.SetText(s);
                        tmp1 = box.Text.Substring(0, selectionIndex);
                        tmp2 = box.Text.Substring(selectionIndex + box.SelectionLength);
                        box.Text = tmp1 + tmp2;
                    }
                    break;
                case Keys.A: // all 
                    box.SelectAll();
                    break;
            }
        }
