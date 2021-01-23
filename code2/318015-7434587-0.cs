                Microsoft.Office.Interop.Excel.PivotTable pivotCache = Globals.ThisAddIn.Application.ActiveWorkbook.PivotCaches().
                    Create(Microsoft.Office.Interop.Excel.XlPivotTableSourceType.xlDatabase, hoursTable2, XlPivotTableVersionList.xlPivotTableVersion12).
                    CreatePivotTable("PivotTable!R1C1", "PivotTable1", Type.Missing, XlPivotTableVersionList.xlPivotTableVersion12);
                Microsoft.Office.Interop.Excel.Shape myChart = lPivotWorksheet.Shapes.AddChart();
                myChart.Chart.SetSourceData(pivotCache.TableRange1, Type.Missing);
                Globals.ThisAddIn.Application.ActiveWorkbook.ShowPivotChartActiveFields = true;
                Microsoft.Office.Interop.Excel.PivotField rowField = (Microsoft.Office.Interop.Excel.PivotField)pivotCache.PivotFields("FieldTitle1");
                rowField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlRowField;
                pivotCache.AddDataField(pivotCache.PivotFields("FieldTitle2"), "Sum of Difference", Microsoft.Office.Interop.Excel.XlConsolidationFunction.xlSum);
                Microsoft.Office.Interop.Excel.PivotField pageField = (Microsoft.Office.Interop.Excel.PivotField)pivotCache.PivotFields("FieldTitle3");
                pageField.Orientation = Microsoft.Office.Interop.Excel.XlPivotFieldOrientation.xlPageField;
                myChart.ScaleHeight(2, Microsoft.Office.Core.MsoTriState.msoFalse, Type.Missing);
                myChart.ScaleWidth(2, Microsoft.Office.Core.MsoTriState.msoFalse, Type.Missing);
                myChart.Left = 200;
                myChart.Top = 120;
                myChart.Chart.ChartTitle.Caption = "Chart Title";
