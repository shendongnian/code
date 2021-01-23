    [WebMethod]
    [ScriptMethod]
        public string GetData(GridSettings grid)
        {
            var query = new FakeComputersRepository().Computers();
            var response = grid.SerializeQuery(query, d => new List<string>
            {
                d.ID.ToString(),
                d.IsOnline.ToString(),
                d.Name,
                d.IP,
                d.User
            });
            return response;
        }
