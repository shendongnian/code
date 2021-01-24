     protected void btnSearch_Click(object sender, EventArgs e)
          {
                string positionvalue =string.Empty;
                string mainconn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                SqlConnection sqlConn = new SqlConnection(mainconn);
                sqlConn.Open();
                SqlCommand com = new SqlCommand();
                string sqlquery = "  SELECT CONCAT(c.FIRSTNAME, ' ', c.LASTNAME) AS 'EmployeeName' , Position FROM[TWCL_OPERATIONS].[dbo].[PP_Employee] c where CONCAT(c.FIRSTNAME, ' ', c.LASTNAME)  LIKE '%' + @EmployeeName + '%' and  position like '%' + @position + '%' ";
        
                com.CommandText = sqlquery;
                com.Connection = sqlConn;
        
                com.Parameters.AddWithValue("@EmployeeName", txtEmployeeName.Text.Trim());
        
                if(ddlPostion.SelectedItem.Text == "All"){
                     positionvalue  ="";
                 }
                com.Parameters.AddWithValue("@position", positionvalue  );
                DataSet ds = new DataSet();
                SqlDataAdapter sda = new SqlDataAdapter(com);
                sda.Fill(ds);
        
                if (ds.Tables[0].Rows.Count == 0)
                {                 
                    Response.Write("<script language='javascript'>window.alert('No Records Found!');window.location='AddEmployee.aspx';</script>");
                }
                else
                {
                    grdEmployee.DataSource = ds;
                    grdEmployee.DataBind();
                }
            }
