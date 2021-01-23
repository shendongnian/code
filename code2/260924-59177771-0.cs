        private void ChklbBatchType_MouseUp(object sender, MouseEventArgs e)
        {
            int index = ((CheckedListBox)sender).SelectedIndex;
            for (int ix = 0; ix < ((CheckedListBox)sender).Items.Count; ++ix)
                if (index != ix) { ((CheckedListBox)sender).SetItemChecked(ix, false);   }
                  else ((CheckedListBox)sender).SetItemChecked(ix, true);
        }
