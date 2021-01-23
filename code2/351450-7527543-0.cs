    protected void btnsaveasset_Click(object sender, EventArgs e)
    {
            if (txtdescription.Text != "" && txtdtrecieved.Text != "" && txtcost.Text != "" && txtmodelno.Text != "" && txtquantity.Text != "")
            {
                try
                {
                    string desc= txtdescription.Text;
                    DateTime dtrecd = Convert.ToDateTime(txtdtrecieved.Text);
                    string cost = txtcost.Text;
                    string modelno = txtmodelno.Text;
                    double quantity = Convert.ToDouble(txtquantity.Text);
                    SqlConnection sqlcon = new SqlConnection(con);
                    sqlcon.Open();
                    string save = "Insert into Asset(Description,Recieveddate,cost,Modelno,Quantity)values(@desc,@date,@cost,@modelno,@quantity)";
                    SqlCommand cmd = new SqlCommand(save, sqlcon);
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.Add("@desc", desc);
                    cmd.Parameters.Add("@date", dtrecd);
                    cmd.Parameters.Add("@cost", cost);
                    cmd.Parameters.Add("@modelno", modelno);
                    cmd.Parameters.Add("@quantity", quantity);
                    cmd.ExecuteNonQuery();
                    sqlcon.Close();
                    //bindassets("", "");
                    btnsaveasset.Enabled = false;
                    txtdescription.Text = "";
                    txtdtrecieved.Text = "";
                    txtcost.Text = "";
                    txtmodelno.Text = "";
                    txtquantity.Text = "";
                    lblErrMsg.Text = "data inserted successfully..";
                    
                }
                catch
                {
                    lblErrMsg.Text = "Please enter valid data and try again...";
                }
            }
            else
            {
                lblErrMsg.Text = "Please enter valid data and try again...";
            }
            Response.Redirect("nameofpage.aspx", false);//does a charm. browser refresh button will repeat last action and from now on that's a Response.Redirect("nameofpage.aspx", false). thus no duplicate records
    }
