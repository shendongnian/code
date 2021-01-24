            var tablesList = new List<DbTable>();
            var dbTable = new DbTable();
            dbTable.Name = "MyTableName";
            dbTable.Fields = new List<string>
            {
                "FirstField",
                "SecondField"
            };
            tablesList.Add(dbTable);
