    List<Entity1> e1List = new List<Entity1>();
    e1List.Add(new Entity1() { ID = 1, E1Column = "E1 a" });
    e1List.Add(new Entity1() { ID = 2, E1Column = "E1 b" });
    
    List<Entity2> e2List = new List<Entity2>();
    e2List.Add(new Entity2() { ID = 1, E2Column = "E2 a" });
    e2List.Add(new Entity2() { ID = 2, E2Column = "E2 b" });
    
    var query = from e1 in e1List
                join e2 in e2List on e1.ID equals e2.ID
                select new { ID = e1.ID, E1Column = e1.E1Column, E2Column = e2.E2Column };
    
    // Bind the DataGrid
    dataGrid1.ItemsSource = query.ToList();
