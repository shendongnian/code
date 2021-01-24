    var result = dbContext.Table1
        .Where(table1Element => ...)    // only if you don't want all elements of Table1 
        .Select(table1Element => new
        {
             // only select the table1 elements that you plan to use:
             Id = table1Element.Id,
             Name = table1Element.Name,
             // Select the items that you want from Table 2:
             Table2Items = table1Element.Table2
                           .Where(table2Element => ...) // only if you don't want all table2 elements
                           .Select(table2Element => new
                           {
                                // Select only the properties of table2 you plan to use:
                                Id = table2Element.Id,
                                Name = table2Element.Name,
                                ...
                                // the following not needed, you already know the value:
                                // Table1Id = table2Element.table1Id, // foreign key
                           })
                           .ToList(),
             // Table3: your new code:
             Table3Items = table1Element.Table3
                           .Select(table3Element => new
                           {
                                // again: only the properties you plan to use
                                Id = table3Element.Id,
                                ...
                                // the following not needed, you already know the value:
                                // Table1Id = table3Element.table1Id, // foreign key
                           })
                           .ToList(),
        });
