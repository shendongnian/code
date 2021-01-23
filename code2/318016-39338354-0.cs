            // assign the new pivot table
            PivotTable pivotTable = (PivotTable)pivotSheet.PivotTables("pivotTableName");
            // Create a pivot chart using a pivot table as its source
            Shape chartShape = pivotSheet.Shapes.AddChart();
            chartShape.Chart.SetSourceData(pivotTable.TableRange1, Type.Missing);
            CurrentWorkbook.ShowPivotChartActiveFields = true;
            chartShape.Chart.ChartType = XlChartType.xlAreaStacked;
