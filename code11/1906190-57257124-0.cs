    this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler( this.listView1_SelectedIndexChanged);
    this.listView1.GotFocus += new System.EventHandler(this.listView1_Focused);
        
    private void listView1_SelectedIndexChanged(object sender, EventArgs e)
    {
    //call startEditing code
    }
    
    private void listView1_Focused(object sender, EventArgs e)
    {
    editTextBox.Focus();
    }
