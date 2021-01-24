        public void InitKeepAlive()
        {
            Task.Run(async () =>
            {
                while (true)
                {
                    await client.GetCollection<Document>("Documents")
                                .AsQueryable()
                                .Select(d => d.Id)
                                .FirstOrDefaultAsync();
                    await Task.Delay(TimeSpan.FromMinutes(1));
                }
            });            
        }
