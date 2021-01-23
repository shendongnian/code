    static int PASSWORD_LENGTH = 8;
    protected void Button1_Click(object sender, EventArgs e)
    {
        userid.Text = "Your id is:     " + id.Text;
        if(id .Text!="")
        {
            string myInt = id.Text.ToString(); 
            password.Text = "Your password is: " + CreateRandomPassword(PASSWORD_LENGTH); 
        }
       }
