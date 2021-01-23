    protected void Page_Load(object sender, EventArgs e)     
    {
       if (!IsPostBack)
       {
         CredentialsManager cm = new CredentialsManager();
         TextBox_Benutzername.Text = cm.Username;
         TextBox_Passwort.Text = cm.Password;     
       }
    }
