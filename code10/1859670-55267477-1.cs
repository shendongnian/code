    public void filter()  
        {  
            using (SqlConnection sqlconn = new SqlConnection(@"Data Source=DESKTOP-IIBSL6N;Initial Catalog=sales_management;Integrated Security=True"))  
            { 
                SqlDataAdapter sqlad = new SqlDataAdapter("select * From Customer", sqlconn);  
                DataTable dtbl = new DataTable();  
                sqlad.Fill(dtbl);  
                DataView dv = dtbl.DefaultView;  
                dv.RowFilter = string.Format("Name like '%{0}%' and Address like ‘%{1}%’ and  office_number like '" + searchoffice.Text + "%' and phone_number like '" + searchphone.Text + "%' and acount_name like '%{0}%'", searchname.Text,searchaddress.Text);  
                customergrid.DataSource = dv.ToTable();  
                dtbl.DefaultView.Sort = "[Name] DESC";  
            }  
        } 
