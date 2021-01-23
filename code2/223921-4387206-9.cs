        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e) {
            if (e.NewValue == CheckState.Checked) {
                IEnumerator myEnumerator;
                myEnumerator = checkedListBox1.CheckedIndices.GetEnumerator();
                int y;
                while (myEnumerator.MoveNext() != false) {
                    y = (int)myEnumerator.Current;
                    checkedListBox1.SetItemChecked(y, false);
                }
            }
        }
