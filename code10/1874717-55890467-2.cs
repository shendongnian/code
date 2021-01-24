     IList<Name> list = new List<Name>();
        list.Add(new Name{ Forename="Bert", Surname="Fred"});
        
        list.Add(new Name { Forename = "John", Surname = "Smith" });
        DataTable table = new DataTable();
        table.Columns.Add("Forename");
        table.Columns.Add("Surname");
        foreach (Name item in list)
        {
            var row = table.NewRow();
            row["Forename"] = item.Forename;
            row["Surname"] = item.Surname;
          
            table.Rows.Add(row);
        }
