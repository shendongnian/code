    protected override void OnPreInit(EventArgs e)
            {
                base.OnPreInit(e);
                Button bb = new Button();
                bb.Click += new EventHandler(bb_Click);
                bb.CausesValidation = true;
                bb.ID = "button1";
                Panel1.Controls.Add(bb);
            }
    
            void bb_Click(object sender, EventArgs e)
            {
                Response.Write("any thing here");
            }
            protected void Page_Load(object sender, EventArgs e)
            {
    
            }
