    public ActionResult Index(View model)
    {
        using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["DB_MYTABLE_CONNECTION_STRING"].ConnectionString))
        {
    
            var myvalue = MyUtil.GenerateKey(model.Name, model.phonenumber);
    
            con.Open();
            string query = "select count(*) from customer where  key=@myvalue";
    
            using (var cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.Add("@myvalue", myvalue);
                int rowsAmount = (int)cmd.ExecuteScalar();
            }
        }
    }
