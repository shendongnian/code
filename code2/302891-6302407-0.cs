    Microsoft.Office.Interop.Excel.Range chartRange ; 
    
                Microsoft.Office.Interop.Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
                Microsoft.Office.Interop.Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(10, 80, 300, 250);
                Microsoft.Office.Interop.Excel.Chart chartPage = myChart.Chart;
    
                chartRange = xlWorkSheet.get_Range("A1", "d5");
                chartPage.SetSourceData(chartRange, misValue);
                chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
