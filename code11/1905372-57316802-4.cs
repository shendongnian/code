    //The other form where the textboxes are getting updated from
    //public string firstname; --> Not needed
    //public string lastname;  --> Not needed
    public Contact contact;
    public FormContact()
    {
        InitializeComponent();
        contact = new Contact();
    }
    public FormContact(Contact _contact)
    {
        InitializeComponent();
        contact = _contact;
        txtFname.Text = contact.FirstName;
        txtLname.Text = contact.LastName;
    }
    private void btnSave_Click(object sender, EventArgs e)
    {
        // contact = new Contact(txtFname.Text, txtLname.Text); --> Not needed
        contact.FirstName = txtFname.Text;
        contact.LastName = txtLname.Text;
        this.DialogResult = DialogResult.OK; // This must be set by you
        this.Close();                        // Close the form instead of hide
    }
