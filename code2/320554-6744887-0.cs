    protected void Page_Init(object sender, EventArgs e)
    {
        Button a = new Button();
        a.Width = 100;
        a.Height = 100;
        a.Text = "one";
        a.Click += new EventHandler(test);
        form1.Controls.Add(a);
    
        Button b = new Button();
        b.Visible = false;
        b.Width = 100;
        b.Height = 100;
        b.Text = "two";
        b.Click += new EventHandler(test2);
        form1.Controls.Add(b);
    }
    
    protected void test(object sender, EventArgs e)
    {
        b.Visible = true;
        Response.Write("aaaaaaaaaaaaaaaaaa");
    }
    
    
    protected void test2(object sender, EventArgs e)
    {
        Response.Write("bbbbbbbbbbbbbbb");
    }
