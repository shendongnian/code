    protected void Page_Load(object sender, EventArgs e)
    {
        if (File.Exists(Server.MapPath("newtxt.txt")))
        {
            TextBox1.Text = System.IO.File.ReadAllText("newtxt.txt");
        }
        else
        {
            Response.Write("<script>alert('File does not exists')</script>");
        }       
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        System.IO.File.WriteAllText("newtxt.txt", TextBox1.Text);
    } 
