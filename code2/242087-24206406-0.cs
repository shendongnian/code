    // Options is a list box
    private void MoveUpButton_Click(object sender,EventArgs e) {							
        int index = Options.SelectedIndex;											
        if (index <= 0) return;
        string item = (string)Options.Items[index - 1];							
        Options.Items.RemoveAt(index - 1);																				
        Options.Items.Insert(index,item);											
        selectedIndexChanged(null,null);																		
        }
    private void MoveDnButton_Click(object sender,EventArgs e) {							
    	int index = Options.SelectedIndex;
    	if (index + 1 >= Options.Items.Count) return;
    	string item = (string)Options.Items[index];
    	Options.Items.RemoveAt(index);
    	Options.Items.Insert(index + 1,item);
    	Options.SelectedIndex = index + 1;
    	}
    // sent when user makes a selection or when he moves an item up or down
    
    private void selectedIndexChanged(object sender,EventArgs e) {
        int index = Selected.SelectedIndex;
        MoveUpButton.Enabled = index > 0;
        MoveDnButton.Enabled = index + 1 < Selected.Items.Count;
        }
