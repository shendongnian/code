    private void SelectionToText(object sender, EventArgs e)
    {
        MyListBoxItem selection = (MyListBoxItem)TextListBox.SelectedItem;
    
        selectionText.Text = "This is the " + selection.Content.ToString();
    
    }
