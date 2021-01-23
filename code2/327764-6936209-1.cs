    public static List<MemberItem> GetMembersItems(string ProjectGuid)
    {
        using (PMEntities context = new PMEntities("name=PMEntities"))
        {
            var items = context.Knowledge_Project_Members.Include("Knowledge_Project").Include("Profile_Information")
                        .Where(p => p.Knowledge_Project.Guid == ProjectGuid)
                        .Select(row => new MemberItem { IdMember = row.IdMember, UserName = row.Profile_Information.UserName });
            return items.ToList();
        }
    }
