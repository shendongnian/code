    public async Task<IActionResult> GetAllAssets()
    {    
        using (var command = _context.Database.GetDbConnection().CreateCommand())
        {
            command.CommandText = "SELECT Id, Title, YearPublished, Cost, Discriminator, ISBN, Author FROM dbo.LibraryAsset";
            _context.Database.OpenConnection();
    
            using (var myDataReader = command.ExecuteReader())
            {
                var dt = new DataTable();
                dt.Load(myDataReader);
    
                var allAssets = dt.AsEnumerable().Select(s => new
                {
                    Id = s.Field<int>("Id"),
                    Title = s.Field<string>("Title"),
                    YearPublished = s.Field<int>("YearPublished"),
                    Cost = s.Field<float>("Cost"),
                    ISBN = s.Field<string>("ISBN"),
                    Author = s.Field<string>("Author")
                }).ToList();
    
                return Ok(allAssets);
            }
        }
    }
