        public static ArrayList GetMembersItems(string ProjectGuid)
        {
            ArrayList items = new ArrayList(); 
             
                  items.AddRange(yourVariable 
                            .Where(p => p.Knowledge_Project.Guid == ProjectGuid)
                            .ToList());
                return items;
        }
