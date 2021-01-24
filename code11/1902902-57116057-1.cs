 public static bool GetSearchData(string searchString, out SearchViewModel searchModel)
        {
            searchModel = new SearchViewModel();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                SqlCommand command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "select Subject, Body from TABLE where Subject = @subject ";
                command.Parameters.AddWithValue("@subject", searchString);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    searchModel = new SearchViewModel();
                    searchModel.Subject = reader.GetValue(0).ToString();
                    searchModel.Body = reader.GetValue(1).ToString();
                    searchModel.Query = searchString;
                }
                connection.Close();
                return true;
            }
            catch (Exception exc)
            {
                exc.ToString();
                return false;
            }
        }
**Updated HomeController**
        SearchViewModel searchModel = new SearchViewModel();
        public ActionResult Index(SearchViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            else
            {
                string searchString = model.Query;
                DataAccess.GetSearchData(searchString, out searchModel);
                return View(searchModel); 
            }
        }
**My div now displays the appropriate results when I search.**
