    protected void CustomerGridview_RowCommand(object sender, GridViewCommandEventArgs e)
    {
            bool flag = false;
            if (e.CommandName.Equals("Insert")) 
            {
                TextBox txtNewName = (TextBox)CustomerGridview.FooterRow.FindControl("txtNewName");                
                DropDownList ddlNewGender = (DropDownList)CustomerGridview.FooterRow.FindControl("ddlNewGender");
                DropDownList ddlNewType = (DropDownList)CustomerGridview.FooterRow.FindControl("cmbNewType");
                CheckBox chkNewActive = (CheckBox)CustomerGridview.FooterRow.FindControl("chkNewActive");
                if (chkNewActive.Checked) flag = true;
                else
                    flag = false;
                SqlConnection con = new SqlConnection(conection);
                con.Open();
                SqlCommand command = con.CreateCommand();
                SqlTransaction transaction;
                // Start a local transaction.
                transaction = con.BeginTransaction();
                // Must assign both transaction object and connection 
                // to Command object for a pending local transaction
                command.Connection = con;
                command.Transaction = transaction;
                try
                {
                    command.CommandText = "Insert into Contact (Name,Sex,Type,IsActive) values('" + txtNewName.Text + "','" + ddlNewGender.SelectedValue.ToString() + "','" + ddlNewType.SelectedValue.ToString() + "','" + flag + "')";
                    command.ExecuteNonQuery();
                    transaction.Commit();
                    Message.Text = "Record has been saved!!";
                }
                catch (Exception ex)
                {
                    Message.Text = "Error Occured!!";
                    try
                    {
                        transaction.Rollback();
                    }
                    catch(Exception ex2)
                    {
                        Message.Text = "Transaction RollBack!";
                    }
                }   
                FillGrid();
            }
        }
