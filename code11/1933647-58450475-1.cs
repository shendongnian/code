    context.BulkMerge(list, options => {
    	options.ColumnMappings.Add(new Z.BulkOperations.ColumnMapping<Customer>(x => x.CustomerID, true));
    	options.ColumnMappings.Add(new Z.BulkOperations.ColumnMapping<Customer>(x => x.Name));
    	
    	var columnMapping = new Z.BulkOperations.ColumnMapping<Customer>(x => x.Description);
    	columnMapping.FormulaUpdate = "DestinationTable.Name + ';' + StagingTable.Description";
    	options.ColumnMappings.Add(columnMapping);
    });
