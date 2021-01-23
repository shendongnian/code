    //button1 will be clicked to open a new form
    private void button1_Click(object sender, EventArgs e)
    {
        this.Visible = false;     // this = is the current form
        SignUp s = new SignUp();  //SignUp is the name of  my other form
        s.Visible = true;
    }
