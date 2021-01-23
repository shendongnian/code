    private void Form1_Load(object sender, EventArgs e) {
        txtAgencyClientCode.DataBindings.Add("Text", bndProposal, "ClientCode", 
                                    false, DataSourceUpdateMode.OnPropertyChanged, null);
        txtAgencyClientCode.TextChanged += new System.EventHandler(txtAgencyClientCode_TextChanged);
    
    }
