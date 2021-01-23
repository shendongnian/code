            string sql_text = "select * from product_master where model_no like @search_string and active=1";
            SqlConnection connection = new SqlConnection(sql_constr);
            SqlCommand cmd = new SqlCommand(sql_text, connection);
            cmd.Parameters.AddWithValue("@search_string", "%" + search_string + "%");
            connection.Open();
            SqlDataReader rdr = cmd.ExecuteReader();
            List<SearchResult> searchresults = new List<SearchResult>();
            while (rdr.Read())
            {
                SearchResult sr = new SearchResult();
                sr.model_no = rdr["model_no"].ToString();
                sr.result_text = rdr["product_name"].ToString();
                sr.url = rdr["url_key"].ToString();
                searchresults.Add(sr);
            }
            connection.Close();
            //build json result
            return Json(searchresults, JsonRequestBehavior.AllowGet);
