    protected void ButtonSave_Click(object sender, EventArgs e)
    {
           SqlConnection con = new SqlConnection("Data Source=LAPTOP-U11A4VS6;Initial Catalog=Task;Integrated Security=True");
           con.Open();
           //SqlCommand cmd = new SqlCommand("Invoice_Product", con);
           //cmd.CommandType = CommandType.StoredProcedure;
           string sqlString = "insert into [Invoice_Product] (@FIELD1, @FIELD2)"
           //put the breakpoint on next line and check the value of sqlString
           SqlCommand cmd = new SqlCommand(sqlString,con);
           cmd.Parameters.Add("@FIELD1", SqlDbType.Int);
           cmd.Parameters["@FIELD1"].Value = TextBoxInvoice.Text;
           cmd.Parameters.Add("@FIELD2", SqlDbType.DateTime);
           cmd.Parameters["@FIELD2"].Value = TextBoxDate.Text;
           
           int k = cmd.ExecuteNonQuery();
            if (k > 0)
           {
                Response.Write("<script> alert ('User Added')</Script>)");
           }
           else Response.Write("<script> alert ('Error')</Script>)");
           //con.Close();
       }   
       
