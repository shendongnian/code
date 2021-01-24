        int index = Convert.ToInt32(radioListBox1.SelectedIndex);
        string indexvalue = Convert.ToString(this.radioListBox1.Items[index]);
        string input = Regex.Replace(indexvalue, "[^0-9]+", string.Empty);
        **The problem was solved, this was missing my code.** 
        if (input.Length == 8) input = input.Insert(4, " - ");
        
        MessageBox.Show(input);
