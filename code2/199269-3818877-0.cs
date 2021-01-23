    private void SetProperties(DataTable dataSource, string valueMember, string displayMember)
    {
        if (dataGridView1.InvokeRequired){
             dataGridView1.Invoke(new DelegateSetProperties(SetProperties), dataSource, valueMember, displayMember);
             return;
        }
    
        dataGridViewComboBoxColumn1.DataSource = dataSource;
        dataGridViewComboBoxColumn1.DisplayMember = valueMember;
        dataGridViewComboBoxColumn1.ValueMember = displayMember";
    }      
