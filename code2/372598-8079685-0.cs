         try
         {
            if (DateTime.Compare(dt1, dt2) > 0)  
            {  
                txtStartDate.BackColor = System.Drawing.Color.Yellow;  
                lblError.Text = "Start Date must not be greater than End Date.";  
            }  
            else
            {
                lblError.Text = "Please enter valid data!";
            }
         }
         catch (Exception ex)
         {
             lblError.Text = "Please enter valid data!";
         }
         finally
         {
            Session["txtFirstName"] = txtFirstName.Text;    
            Session["txtLastName"] = txtLastName.Text;    
            Session["txtPayRate"] = txtPayRate.Text;    
            Session["txtStartDate"] = txtStartDate.Text;    
            Session["txtEndDate"] = txtEndDate.Text;    
            Server.Transfer("frmPersonalVerified.aspx");
         }
