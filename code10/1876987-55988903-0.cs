    public ActionResult Index()
            {
    
                DataSet dt = new DataSet();
    
    
    
                using (SqlConnection sqlcon = new SqlConnection("ABC"))
                {
                    sqlcon.Open();
                    SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Person", sqlcon);
                    sqlDa.Fill(dt, "Person");
                }
    
                return View(dt.Tables["Person"]);
            }
