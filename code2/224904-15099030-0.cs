        public static ArrayList GetMembersItems(string ProjectGuid)
        {
            ArrayList items = new ArrayList(); 
            items.AddRange(yourVariable 
                            .Where(p => p.yourProperty == something)
                            .ToList());
            return items;
        }
