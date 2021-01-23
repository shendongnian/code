    //get range for pivot table destination
    Range pivotDestinationRange = pivotWorkSheet.get_Range("A1", Type.Missing);
    
    wrkBook.PivotTableWizard(
                        XlPivotTableSourceType.xlDatabase,
                        "MyNamedRange",
                        pivotDestinationRange,
                        pivotTableName,
                        true,
                        true,
                        true,
                        true,
                        Type.Missing,
                        Type.Missing,
                        false,
                        false,
                        XlOrder.xlDownThenOver,
                        0,
                        Type.Missing,
                        Type.Missing
                        );
