    // set up DataTable with countries:
    countriesTable = new DataTable("Countries");
    countriesTable.Columns.Add("CountryID", typeof(int));
    countriesTable.Columns.Add("CountryName", typeof(string));
    countriesTable.Rows.Add(1, "England");
    countriesTable.Rows.Add(2, "Spain");
    ...
    
    // set up DataTable with towns:
    townsTable = new DataTable("Towns");
    townsTable.Columns.Add("TownID", typeof(int));
    townsTable.Columns.Add("TownName", typeof(string));
    townsTable.Columns.Add("CountryID", typeof(int));    // <-- this is a foreign key
    townsTable.Rows.Add(1, "London", 1);
    townsTable.Rows.Add(2, "Brighton", 1);
    townsTable.Rows.Add(3, "Barcelona", 2);
    ...
