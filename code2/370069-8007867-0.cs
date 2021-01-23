    // if table contains multiple rows per id
    var resultSet = ids.SelectMany(id => context.Table.Where(tbl => tbl == id));
    
    // if table contains one row per id
    var resultSet = ids.Select(id => context.Table.Where(tbl => tbl == id).Single());
