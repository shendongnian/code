        public void Method_2(List<DbTable> tables)
        {
            foreach (var table in tables)
            {
                foreach (var field in table.Fields)
                {
                    var phones = cntDB.Database.ExecuteSqlCommand("SELECT " + field + " FROM " + table.Name); // +-
                    lst_List.AddRange(phones.ToList());
                }
            }
        }
