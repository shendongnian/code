    private void LoadAccounts()
    {
        accounts.Clear();
        accounts = accountsOnDatabase.ToList();
        UpdateListBox();
    }
    
    private void btnAddCash_Click(object sender, EventArgs e)
    {
        string userName = listBox1.GetItemText(listBox1.SelectedItem);
    
        if (int.TryParse(txtAddCash.Text, out int cash))
        {
            DialogResult dr = MessageBox.Show($"Add {txtAddCash.Text} cash to {userName}?", "Add Cash", MessageBoxButtons.YesNo);
            if (dr == DialogResult.No)
                return;
    
            AccountModel AccOnDataBase = accountsOnDatabase.Where(a => a.Username == userName).FirstOrDefault();
            if (AccOnDataBase == null) return;
    
            AccountModel acc = new AccountModel();
            acc.Username = userName;
            acc.LeftCash = cash + AccOnDataBase.LeftCash; //DBAccess.AddCash
    
            accountsOnDatabase.RemoveAll(a => a.Username == acc.Username);
            accountsOnDatabase.Add(acc);
    
            txtAddCash.Text = "";
    
            LoadAccounts();
        }
    }
    private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (listBox1.SelectedItem == null) return;
    
        string selected = ((AccountModel)listBox1.SelectedItem).Username;
        int leftCash = accounts.Where(a => a.Username == selected).Select(a => a.LeftCash).First();
    
        label1.Text = leftCash.ToString();
    }
