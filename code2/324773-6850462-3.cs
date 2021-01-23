        for (int line = 0; line < placementTwoListBox.Items.Count; line++)
        {
            string replacement1 = calculatedXRichTextBox.Lines[line];
            while (replacement1.Length < 7)
            {
                replacement1 = " " + replacement1;
            }
            placementTwoListBox.Items[line] = ((string)placementTwoListBox.Items[line]).Remove(20, 7).Insert(20, replacement1);
            string replacement2 = calculatedYRichTextBox.Lines[line];
            while (replacement2.Length < 7)
            {
                replacement2 = " " + replacement2;
            }
            placementTwoListBox.Items[line] = ((string)placementTwoListBox.Items[line]).Remove(29, 7).Insert(29, replacement1);
        }
