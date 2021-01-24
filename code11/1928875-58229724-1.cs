     protected void Page_Load(object sender, EventArgs e)
          {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=A**SE****D***\MSSQL****;Initial Catalog=****;User 
            ID=****;Password=****";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
    
    
            SqlCommand cmd = new SqlCommand(@"SELECT * from TV_LABCASE C Left join TV_DEPTNAME D ON C.DEPARTMENT_CODE = D.DEPARTMENT_CODE Left join TV_OFFENSE O ON C.OFFENSE_CODE = O.OFFENSE_CODE", cnn);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            DropDownList1.DataSource = dt;
            DropDownList1.DataBind();
            DropDownList1.DataTextField = "DEPARTMENT_NAME";
            DropDownList1.DataValueField = "DEPARTMENT_CODE";
            DropDownList1.DataBind();
    
            DropDownList2.DataSource = dt;
            DropDownList2.DataBind();
            DropDownList2.DataTextField = "OFFENSE_DESCRIPTION";
            DropDownList2.DataValueField = "OFFENSE_CODE";
            DropDownList2.DataBind();
    
    
        }
