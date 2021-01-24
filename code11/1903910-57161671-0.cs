    // Chart
    Microsoft.Office.Interop.Excel.ChartObjects mainChartObjects = (Microsoft.Office.Interop.Excel.ChartObjects)pivotWorksheet.ChartObjects();
    Microsoft.Office.Interop.Excel.ChartObject mainChartObject = (Microsoft.Office.Interop.Excel.ChartObject)mainChartObjects.Add(0, 0, 500, 500);
    Microsoft.Office.Interop.Excel.Chart mainChart = (Microsoft.Office.Interop.Excel.Chart)mainChartObject.Chart;
    ExcelWorkbook.ActiveSheet.Range(pivotTableStartRange, pivotTableEndRange).Select();
    Microsoft.Office.Interop.Excel.Range fullPivotRange = excelWriter.ExcelWorkbook.ActiveSheet.Range(pivotTableStartRange, pivotTableEndRange);
    mainChart.SetSourceData(fullPivotRange);
    // Set Chart Type
    mainChart.PlotArea.Select();
    mainChart.ChartArea.Select();
    mainChart.ChartType = Microsoft.Office.Interop.Excel.XlChartType.xlPyramidColStacked;
    mainChart.ChartStyle = 419;
    // Plot By
    mainChart.PlotBy = Microsoft.Office.Interop.Excel.XlRowCol.xlRows;
    // Remove 3D Rotations
    Excel.ActiveChart.PlotArea.Select();
    Excel.Selection.Format.ThreeD.FieldOfView = 5;
    Excel.Selection.Format.ThreeD.RotationX = 0;
    Excel.Selection.Format.ThreeD.RotationY = 90;
    // Legend
    Excel.ActiveChart.SetElement(Microsoft.Office.Core.MsoChartElementType.msoElementLegendBottom);
