    protected void Page_Load(object sender, EventArgs e)
    {
        .
        .
        Button Button1= new Button();
        Button1.ID = "button1";
        Button1.Text = "Button";
        Button1.Click+=new EventHandler(Button1_Click);
        this.form1.Controls.Add(Button1);
        .
        .
    }
