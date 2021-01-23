    protected void Page_Load(object sender, EventArgs e) {
       LoadUsers();
    }
    
    void b_Click(object sender, EventArgs e) {		
       Button button = (Button)sender;
       string firstName = button.CommandArgument;  
       DbDB.User.Delete(x => x.FirstName == firstName);
    
       PlaceHolder1.Controls.Remove(button);
    }
    
    void LoadUsers() {	
       DbDB db = new DbDB();
       List<User> users = db.GetUsers().ExecuteTypedList<User>();
    	
       foreach (User user in Users) {
          Button button = new Button();			
          button.CommandArgument = user.FirstName;	// normally the user "id" to identify the user.
          button.Text = user.FirstName;
          button.Click += new EventHandler(b_Click);
          PlaceHolder1.Controls.Add(button);
       }
    }
