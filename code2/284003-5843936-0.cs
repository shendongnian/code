        private List<SqlParameter> insertParameters = new List<SqlParameter>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            SqlParameter fName = new SqlParameter("@First", SqlDbType.VarChar, 30);
            fName.Direction = ParameterDirection.Input;
    
            fName.Value = txtFirst.Text;
            SqlParameter lName = new SqlParameter("@Last", SqlDbType.VarChar, 30);
            lName.Direction = ParameterDirection.Input;
    
            lName.Value = txtLast.Text;
    
            insertParameters.Add(fName);
            insertParameters.Add(lName);
            SqlDataSource1.Insert();
        }
        
        protected void SqlDataSource1_Inserting(object sender, SqlDataSourceCommandEventArgs e)
        {
    
            e.Command.Parameters.Clear();
    
            foreach (SqlParameter p in insertParameters)
    
                e.Command.Parameters.Add(p);
        }
    }
