     protected void Page_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
    
                Button bt = new Button();
                bt.Text = "" + i;
                bt.ID = "btn" + i; // Assign unique ID
                bt.Click += new EventHandler(bt_Click);
                Panel1.Controls.Add(bt);
            }
            AddButtons();
        }
    
        public void bt_Click(object sender, EventArgs e)
        {
            ViewState["btnId"] = (sender as Button).ID ;
            AddButtons();
        }
    
        public void AddButtons()
        {
            if (ViewState["btnId"] == null)
                return;
            Button selected = Panel1.FindControl(ViewState["btnId"].ToString()) as Button;
            
            Panel1.Visible = false;
            Label lbl = new Label();
            lbl.Text = "i am lable";
            Panel2.Controls.Add(lbl);
            for (int i = 1; i < 30; i++)
            {
    
                Button pb = new Button();
    
                pb.Text = selected.Text;
    
                pb.Click += new EventHandler(pb_Click);
                Panel2.Controls.Add(pb);
    
            }
        }
