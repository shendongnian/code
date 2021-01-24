        public static Dictionary<string, int> group = new Dictionary<string, int>();
        public static void adduniquevalue(aperson person,int id)
        {
            
            if (person.Email != null && !group.Keys.Contains(person.Email))
            {
                group.Add(person.Email, id);
            }
            if (person.Phone != null && !group.Keys.Contains(person.Phone))
            {
                group.Add(person.Phone, id);
            }
            if (person.Name != null && !group.Keys.Contains(person.Name))
            {
                group.Add(person.Name, id);
            }
        }
        public static void CreateGroupKeys(aperson person)
        {
            int id = group.Count;
            List<int> groupmatches = new List<int>();
            if (person.Email != null && group.Keys.Contains(person.Email)) 
                groupmatches.Add(group[person.Email]);  
            if (person.Phone != null && group.Keys.Contains(person.Phone)) 
                groupmatches.Add(group[person.Phone]); 
            if (person.Name != null && group.Keys.Contains(person.Name)) 
                groupmatches.Add(group[person.Name]); 
            if (groupmatches.GroupBy(x=>x).Count() > 1)
            {
                int newid = groupmatches[0];
                group.Keys.Where(key => groupmatches.Contains(group[key]))
                          .ToList()
                          .ForEach(key => { group[key] = newid; }); 
            }
            if (groupmatches.Count == 0)
              adduniquevalue(person, id);
            else adduniquevalue(person, groupmatches[0]);
        }
        public static int GetGroupKey(aperson person)
        {
            if (person.Email != null && group.Keys.Contains(person.Email))
                return group[person.Email]; 
            if (person.Phone != null && group.Keys.Contains(person.Phone))
                return group[person.Phone]; 
            if (person.Name != null && group.Keys.Contains(person.Name))
                return group[person.Name];
            else return 0;
        }
