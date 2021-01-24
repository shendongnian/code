    // Access the pivot table by its name in the collection. 
    PivotTable pivotTable = worksheet.PivotTables["PivotTable1"];
    
    
    // Access the pivot field by its name in the collection. 
    PivotField field = pivotTable.Fields["Category"];
    
    
    // Display multiple subtotals for the field.   
    field.SetSubtotal(PivotSubtotalFunctions.Sum | PivotSubtotalFunctions.Average);
    
    // Show all subtotals at the bottom of each group. 
    pivotTable.Layout.ShowAllSubtotals(false);
    
    // Hide grand totals for rows.
    pivotTable.Layout.ShowRowGrandTotals = False
    
    // Hide grand totals for columns.
    pivotTable.Layout.ShowColumnGrandTotals = False
    // custom label for grand totals
    pivotTable.View.GrandTotalCaption = "Total Sales";
