        public static async Task<List<object>> GetKinderGartenIssues()
        {
            try
            {
                var users = new List<object>();
                using (var entities = new WebPortalEntities())
                {
                    users = await entities.KindergartenIssues_Users
                    .Where(k => k.DeletedDate == null)
                    .Join(entities.Users, o => o.UserId, i => i.UserId, (ki, u) => {
// You can obviously define your class somewhere instead of using anonymous object...
                        return new {
                            ID = ki.ID,
                            UserId = ki.UserId,
                            FullName = u.FullName
                            // etc...
                        };
                    }).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                CommonHelper.WriteError($"GetKinderGartenIssues ERROR: {JsonConvert.SerializeObject(ex)}");
            }
            return users;
        }
