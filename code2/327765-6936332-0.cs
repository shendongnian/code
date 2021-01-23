    public class UserDetail
    {
       public int Id{get;set;}
       public string UserName {get;set;}
    }
    
    public static List<UserDetail> GetMembersItems(string ProjectGuid)
        {
            using (PMEntities context = new PMEntities("name=PMEntities"))
            {
                var items = context.Knowledge_Project_Members.Include("Knowledge_Project").Include("Profile_Information")
                            .Where(p => p.Knowledge_Project.Guid == ProjectGuid)
                            .Select(row => new UserDetail{ IdMember = row.IdMember, UserName = row.Profile_Information.UserName });
    
                return items.ToList();
            }
        }
