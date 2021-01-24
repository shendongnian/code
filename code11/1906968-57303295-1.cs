        [HttpPost]
        public ActionResult Search(YOUR_MODEL model)
        {
            IFS_Catalog_Products DatabaseScanner = new IFS_Catalog_Products();
            string catDesc = "";
            if (ModelState.IsValid)
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = @"CONNECTION STRING";
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DESCRIPTION FROM TABLE WHERE NUMBER = '" + model.Number+ "'", con);
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    catDesc = dr.GetString(0);
                    //break;
                }
                    con.Close();
            }
            DatabaseScanner.IFS_Catalog_Desc = catDesc;
            DatabaseScanner.IFS_Catalog_No = catNo;
            return View("Create", DatabaseScanner);
        }
