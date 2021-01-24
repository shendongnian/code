        public Category GetCategoryByCategoryName(string categoryName)
        {
            using (OleDbConnection con = new OleDbConnection(_connectionString))
            {
                return con.QueryFirstOrDefault<Category>(
                  "select * from Categories where CategoryName=?cn?",
                  new { cn = categoryName }
                );
            }
        }
