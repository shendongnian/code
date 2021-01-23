        var table = new DataTable();
        table.Columns.Add("Meaning");
        table.Columns.Add("Phrase");
        for (int i = 0; i < 5; i++)
        {
            var row = table.NewRow();
            row["Meaning"] = "Meaning"+i;
            row["Phrase"] = "Phrase"+i;
            table.Rows.Add(row);
        }
        
        var super = from lang in table.AsEnumerable()
                    where lang.Field<string>("Meaning") == "Meaning1" 
                    select lang.Field<string>("Phrase");
        foreach (string item in super)
        {
            Console.Write(item + "\n");
        }
        Console.ReadLine();
