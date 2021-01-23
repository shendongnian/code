    StatsForm  sFrm = new StatsForm  ();
    public gameFrm()
    {
    InitializeComponent();
    }
    
    private void btnShowStateForm_Click(object sender, EventArgs e)
    {
    sFrm.Show(); //or call
    //    sFrm.ShowDialog();
    }
    
    private void gameFrm_FormClosing(object sender, FormClosingEventArgs e)
    {
    sFrm.Close();
    }
