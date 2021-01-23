    usernLbl.ForeColor = ValidateUsername(usrnTxtbox.Text);
    nameLbl.ForeColor = ValidateName(nameTxtbox.Text);
    public Color ValidateUsername(string username)
    {
        if(<first BAD condition>)
        {
            return Color.Red;
        }
        //etc.
        return Color.Black;
    }
