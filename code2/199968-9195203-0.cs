        List<int> listBox2_selectionhistory = new List<int>();
        private void checkedListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            int actualcount = listBox2_selectionhistory.Count;
            if (actualcount == 1)
            {
                if (Control.ModifierKeys == Keys.Shift)
                {
                    int lastindex = listBox2_selectionhistory[0];
                    int currentindex = checkedListBox2.SelectedIndex;
                    int upper = Math.Max(lastindex, currentindex) ;
                    int lower = Math.Min(lastindex, currentindex);
                    for (int i = lower; i < upper; i++)
                    {
                        checkedListBox2.SetItemCheckState(i, CheckState.Checked);
                    }
                }
                listBox2_selectionhistory.Clear();
                listBox2_selectionhistory.Add(checkedListBox2.SelectedIndex);
            }
            else
            {
                listBox2_selectionhistory.Clear();
                listBox2_selectionhistory.Add(checkedListBox2.SelectedIndex);
            }
        }
