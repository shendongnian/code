                    if (!mdr.HasRows)
                    {
                        Reg();
                    }
                    else
                    {
                        ErrorLbl.Visible = true;
                        ErrorLbl.Text = "User exists already";
                        ErrorLbl.CssClass = "text-danger";
                    }
    
     
