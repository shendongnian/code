    protected void Page_Load(object sender, EventArgs e) {
        if(!Page.IsPostBack){
           LoadUsers();
        }
    }
        
    void b_Click(object sender, EventArgs e) {    
        Button b = (Button)sender;
        DbDB.User.Delete(x => x.FirstName == b.Text);
        LoadUsers();
        
    }
