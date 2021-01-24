     IList<Name> list = new List<Name>();
        list.Add(new Name{ Forename="Bert", Surname="Fred"});
        
        list.Add(new Name { Forename = "John", Surname = "Smith" });
        DataTable table = new DataTable();
        
        foreach (Name n in list)
        {
            //if it doesnt work use: table.Columns.Add("Forename", typeof(String)); 
            table.Columns.Add("Forename");
            table.Columns.Add("Surname");
        
            table.Rows.Add(new DataRow(n.Forename, n.Surname));
        }
