    if (DateTime.Compare(dt1, dt2) > 0)
            {
                try
                {
                    txtStartDate.BackColor = System.Drawing.Color.Yellow;
                    lblError.Text = "Start Date must not be greater than End Date.";
                }
                catch (Exception ex)
                {
                    lblError.Text = "Please enter valid data!";
                }
            }
    
            else
            {
                Session["txtFirstName"] = txtFirstName.Text;
                Session["txtLastName"] = txtLastName.Text;
                Session["txtPayRate"] = txtPayRate.Text;
                Session["txtStartDate"] = txtStartDate.Text;
                Session["txtEndDate"] = txtEndDate.Text;
                Server.Transfer("frmPersonalVerified.aspx");
            }
