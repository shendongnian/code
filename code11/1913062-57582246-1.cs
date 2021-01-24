        public async Task getOrg()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "organizations");
            var response = await _client_NP.SendAsync(request);
            var json = await response.Content.ReadAsStringAsync();
            OrganizationsClass.OrgsRootObject model = JsonConvert.DeserializeObject<OrganizationsClass.OrgsRootObject>(json);
            using (var scope = _scopeFactory.CreateScope())
            {
                var dbContext = scope.ServiceProvider.GetRequiredService<DBcontext>();
                foreach (var item in model.resources)
                {
                    var g = Guid.Parse(item.guid);
                    var x = dbContext.Organizations.FirstOrDefault(o => o.OrgGuid == g);
                    if (x == null)
                    {
                        dbContext.Organizations.Add(new Organizations
                        {
                            OrgGuid = g,
                            Name = item.name,
                            CreatedAt = item.created_at,
                            UpdatedAt = item.updated_at,
                            Timestamp = DateTime.Now,
                            Foundation = 3
                        });
                    }
                    else if (x.UpdatedAt != item.updated_at)
                    {
                        x.CreatedAt = item.created_at;
                        x.UpdatedAt = item.updated_at;
                        x.Timestamp = DateTime.Now;
                    }
                }
                await dbContext.SaveChangesAsync();
            }
        }
