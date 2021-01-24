    protected void ButtonSave_Click(object sender, EventArgs e)
    {
           SqlConnection con = new SqlConnection("Data Source=LAPTOP-U11A4VS6;Initial Catalog=Task;Integrated Security=True");
           con.Open();
           //SqlCommand cmd = new SqlCommand("Invoice_Product", con);
           //cmd.CommandType = CommandType.StoredProcedure;
           string sqlString = "insert into [Invoice_Product] (" + Convert.ToInt32(TextBoxInvoice.Text)
             + "','"+Convert.ToInt32(TextBoxInvoice.Text)+"','"+"'"+TextBoxDate.Text+"'"
             + "','"+"'"+DropDownList1.SelectedItem.Text+"'"
             +"','"+"'"+DropDownList2.SelectedItem.Text+"'"+"','"+Convert.ToDouble(LabelPrice1.Text) 
             + "','"+Convert.ToInt32(TextBoxQty.Text)+"','"+Convert.ToDouble(LabelTot1.Text)
             + "','"+Convert.ToDouble(LabelDiscount1.Text)+"','"+Convert.ToDouble(LabelNet1.Text)  
             + "','"+"'"+DropDownListStores.SelectedItem.Text+"'"+"','"+Convert.ToDouble(TextBoxFinalTot.Text)
             + "','"+Convert.ToDouble(TextBoxTaxes.Text)+ "','"+Convert.ToDouble(TextBoxFinalNet.Text)+")"
           //put the breakpoint on next line and check the value of sqlString
           SqlCommand cmd = new SqlCommand(sqlString,con);
           int k = cmd.ExecuteNonQuery();
            if (k > 0)
           {
                Response.Write("<script> alert ('User Added')</Script>)");
           }
           else Response.Write("<script> alert ('Error')</Script>)");
           //con.Close();
       }   
