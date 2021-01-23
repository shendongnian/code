     protected void Page_Load(object sender, EventArgs e)
    {   
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["productID"] != null)
            {
                productID = Convert.ToInt32(Request.QueryString["productID"]);
                bindData(productID)
            }
            ...
        }
     }
       protected void bindData(int productID)
        {
         //to avoid sql injection as mentioned below use parameters 
          SqlConnection conn = new SqlConnection(ConnectionString); // define connection string globally or in your business logic
          conn.Open();
          SqlCommand sql = new SqlCommand("Select * From [Table] Where ID = @productID",conn);
          SqlParameter parameter = new SqlParameter();
          parameter.ParameterName = "@ID";
	   parameter.Value = productID;
           sql.Parameters.Add(parameter);
           conn.close()
      }
