     protected void Page_Load(object sender, EventArgs e)
        {
            TextBox txtbx= null;    
            DropDownList ddl = null;
    
            for (int i = 0; i < 4; i++)
            {               
                txtbx= new TextBox();
                txtbx.ID = "mytxt" + i; 
                txtbx.Text = "mytxt" + i;            
                
                pnlButton.Controls.Add(txtbx);    
                
                ddl= new DropDownList();
                ddl.ID = "mydropdown " + j;
                ddl.Text = "mydropdown " + j;
                ddl.Items.Add("Hii");
                ddl.Items.Add("Hello");
                ddl.AutoPostBack = true;
                ddl.SelectedIndexChanged += new EventHandler(ddl_Click);
    
                pnlButton.Controls.Add(ddl);
                Literal lit = new Literal();
                lit.Text = "</br></br>";
                pnlButton.Controls.Add(lit);
            }
        }
