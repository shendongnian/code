            int lastIndex = -1;
            //get line number of item
            do
            {
                index = textBoxItems.Find(s, index + 1, RichTextBoxFinds.MatchCase);
                if (index != -1) {
                   lastIndex = index;
                }
            } while ((index != -1));
            if (lastIndex !+ -1) {
                int lineNum = textBoxItems.GetLineFromCharIndex(lastIndex);
                //messageBox.Show(""+lineNum);
                textBoxCount.Text.Remove(index, 3);
                textBoxCount.Text.Insert(index, "(" + mainItems[itemID] + ")");
            }
