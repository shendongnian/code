    //out key word is used in function instead of return. we can use multiple parameters by using out key word
    public void outKeyword(out string Firstname, out string SecondName)
    {
        Firstname = "Muhammad";
        SecondName = "Ismail";
    
    }
    //on button click Event
    protected void btnOutKeyword_Click(object sender, EventArgs e)
    {
        string first, second;
        outKeyword(out first, out second);
        lblOutKeyword.Text = first + "  " + second;
    }
