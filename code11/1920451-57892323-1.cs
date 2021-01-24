        public async Task<IEnumerable<UserDto>> GetAllAsync(string token, string baseUrl)
        {
            using (HttpClient client = new HttpClient())
            //Setting up the response...         
            using (HttpResponseMessage res = await client.GetAsync(baseUrl +
            "users?access-token=" + token))
            using (HttpContent content = res.Content)
            {
                string json = await content.ReadAsStringAsync();
                var rootObject = JsonConvert.DeserializeObject<RootObject>(json);
                var users = new List<UserDto>();
                // Now map the result to UserDto
                foreach (var r in rootObject.result)
                {
                    users.Add(
                        new UserDto
                        {
                            id = int.Parse(r.id),
                            first_name = r.first_name,
                            last_name = r.last_name,
                            username = r.id, // We don't receive a username back?
                            gender = r.gender,
                            dob = r.dob,
                            email = r.email,
                            phone = r.phone,
                            website = r.website,
                            address = r.address,
                            status = r.status,
                            links = new List<string> // Looks like the response includes 3 links to self, edit and avatar
                            {
                                r._links.self.href,
                                r._links.edit.href,
                                r._links.avatar.href
                            }
                        });
                }
                return users;
            }
        }
