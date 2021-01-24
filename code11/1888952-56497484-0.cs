             if (mdr.HasRows)
                {
                    mdr.Read();
                    string rr = mdr.GetString("username");
                    closeConnection();
                    if (!TUname.Text.Equals(rr))
                    {
                        Reg();
                    }
                    else
                    {
                        ErrorLbl.Visible = true;
                        ErrorLbl.Text = "User exists already";
                        ErrorLbl.CssClass = "text-danger";
                    }
                }
    
     
