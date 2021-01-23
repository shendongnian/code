    public static List<Object> GetMembersItems(string ProjectGuid)
    {
        using (PMEntities context = new PMEntities("name=PMEntities"))
        {
            var items = context.Knowledge_Project_Members.Include("Knowledge_Project").Include("Profile_Information")
                        .Where(p => p.Knowledge_Project.Guid == ProjectGuid)
                        .Select(row => new { IdMember = row.IdMember, UserName = row.Profile_Information.UserName });
            return items
                   .ToList() // this is only needed to make EF happy otherwise it complains about the cast
                   .Cast<Object>()
                   .ToList();
        }
    }
