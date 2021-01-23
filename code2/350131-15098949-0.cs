        public static ArrayList GetMembersItems(string ProjectGuid)
        {
            ArrayList items = new ArrayList(); 
             
                  items.AddRange(yourVariable 
                            .Where(p => p.yourproperty == something)
                            .ToList());
                return items;
        }
