    public ActionResult Sumthem() {
        string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        using (SqlConnection con = new SqlConnection(constr))
        {
            SqlCommand cmd = new SqlCommand("SELECT SUM (Final) FROM SomeTable", con);
            cmd.Connection.Open();
    
            ViewBag.FinalSUM = cmd.ExecuteScalar().ToString();
    
            return PartialView("Records", new YourModel())
        }   
    }    
