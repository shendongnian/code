    public bool createReport_NewMinusBase(string currentWorkingDirectory, string Book1, string Book2, double tolerance)
    {
        tolerance = 0.0001;
        myExcel.Application excelApp = new myExcel.Application();  // Creates a new Excel Application
        excelApp.Visible = false;  // Makes Excel visible to the user.
        excelApp.Application.DisplayAlerts = false;
        //useful for COM object interaction
        object missing = System.Reflection.Missing.Value;
        //Return value
        bool wereDifferences = false;
        //Comparison objects
        object objNew = null;
        object objBase = null;
        //source: http://www.codeproject.com/KB/office/csharp_excel.aspx
        //xlApp.Workbooks.Open(reportFolder + reportName, 0, false, 5, "", "", false, myExcel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
        //Open BASE FILE
        myExcel.Workbook excelWorkbook1 = excelApp.Workbooks.Open(@currentWorkingDirectory + Book1, 0,
                                          missing, missing, missing, missing, missing, missing, 
                                          missing,missing, missing, missing, missing, missing, missing);
        //OPEN NEW FILE
        myExcel.Workbook excelWorkbook2 = excelApp.Workbooks.Open(@currentWorkingDirectory + Book2, 0, 
                                          missing, missing, missing, missing, missing, missing, 
                                          missing, missing, missing, missing, missing, missing, missing);
        myExcel.Workbook excelWorkbook3 = excelApp.Application.Workbooks.Add(myExcel.XlWBATemplate.xlWBATWorksheet);
        myExcel.Worksheet wsBase;
        myExcel.Worksheet wsDiff;
        myExcel.Worksheet wsNew;
        try
        {
            wsBase = (myExcel.Worksheet)excelApp.Workbooks[Book1].Sheets["Sheet1"];
            wsNew = (myExcel.Worksheet)excelApp.Workbooks[Book2].Sheets["Sheet1"];
            wsDiff = (myExcel.Worksheet)excelWorkbook3.Worksheets.get_Item(1);
        }
        catch
        {
            throw new Exception("Excel file does not contain properly formatted worksheets");
        }
        //Copy Sheet from Excel Book "NEW" to "NEW(-)BASE"
        myExcel.Worksheet source_sheet;
        source_sheet = (myExcel.Worksheet)excelApp.Workbooks[Book2].Sheets["Sheet1"];
        source_sheet.UsedRange.Copy();
        wsDiff.Paste();
        
        //Determine working area
        int row = 0;
        int col = 0;
        int maxR = 0;
        int maxC = 0;
                    
        int lr1 = 0;
        int lr2 = 0;
        int lc1 = 0;
        int lc2 = 0;
        {
            lr1 = wsNew.UsedRange.Rows.Count;
            lc1 = wsNew.UsedRange.Columns.Count;
        }
        {
            lr2 = wsBase.UsedRange.Rows.Count;
            lc2 = wsBase.UsedRange.Columns.Count;
        }
        maxR = lr1;
        maxC = lc1;
        if (maxR < lr2) maxR = lr2;
        if (maxC < lc2) maxC = lc2;
        //===================================================
        //Compare Cells
        //===================================================
        
        for (row = 1; row <= maxR; row++)
        {
            for (col = 1; col <= maxC; col++)
            {
                //Get cell values
                objNew = ((myExcel.Range)wsNew.Cells[row, col]).Value2;
                objBase = ((myExcel.Range)wsBase.Cells[row, col]).Value2;
                //If they are not equivilante
                if (!equiv(objNew, objBase, tolerance))
                {
                    wereDifferences = true;
                    //Mark differing cells
                    ((myExcel.Range)wsNew.Cells[row, col]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    ((myExcel.Range)wsBase.Cells[row, col]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    if ((objNew == null))
                    {                            
                        ((myExcel.Range)wsDiff.Cells[row, col]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    }
                    else if (objNew.GetType().ToString() == "System.String")
                    {
                        ((myExcel.Range)wsDiff.Cells[row, col]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Red);
                    }
                    else
                    {
                        ((myExcel.Range)wsDiff.Cells[row, col]).Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Yellow);
                        ((myExcel.Range)wsDiff.Cells[row, col]).Value2 = ((myExcel.Range)wsNew.Cells[row, col]).Value2 - ((myExcel.Range)wsBase.Cells[row, col]).Value2;
                    }
                }
                else //They are equivalent
                {                        
                    if ((objNew == null))
                    {
                    }
                    else if (objNew.GetType().ToString() == "System.String")
                    {
                    }
                    else
                    {                            
                        ((myExcel.Range)wsDiff.Cells[row, col]).Value2 = ((myExcel.Range)wsNew.Cells[row, col]).Value2 - ((myExcel.Range)wsBase.Cells[row, col]).Value2;
                    }
                }
            }
        }
        // Copy formatting
        myExcel.Range range1 = wsBase.get_Range((myExcel.Range)wsBase.Cells[1, 1], (myExcel.Range)wsBase.Cells[maxR, maxC]);
        myExcel.Range range2 = wsDiff.get_Range((myExcel.Range)wsDiff.Cells[1, 1], (myExcel.Range)wsDiff.Cells[maxR, maxC]);
        range1.Copy();
        range2.PasteSpecial(myExcel.XlPasteType.xlPasteColumnWidths);
        excelApp.Workbooks[Book1].Close(false, false, false);
        excelApp.Workbooks[Book2].Close(false, false, false);
        string Book3 = "reporttestpc.xlsx"; //"reportBaseMinusNew.xlsx"
        if (File.Exists(currentWorkingDirectory + Book3))
        {
            File.Delete(currentWorkingDirectory + Book3);
        }
       
        excelWorkbook3.SaveAs(currentWorkingDirectory + Book3, Type.Missing, Type.Missing,
                             Type.Missing, false, false, myExcel.XlSaveAsAccessMode.xlNoChange,
                             Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);
       
        //excelApp.Workbooks[Book3].Close(false, false, false);
        excelApp.Visible = true;
        return wereDifferences;
    }
    /// Determines whether two objects are equivalent
    /// Numbers are equivalent within the specified tolerance
    /// Strings are equivalent if they are identical
    /// obj1 and obj2 are the two objects being compared
    /// tolerance is the maximum difference between two numbers for them to be deemed equivalent
    private bool equiv(object obj1, object obj2, double tolerance)
    {
        if ((obj1 == null) && (obj2 == null))
        {
            return true;
        }
        else if ((obj1 == null) || (obj2 == null))
        {
            return false;
        }
        //if both are numeric
        if (IsNumeric(obj1))
        {
            if (IsNumeric(obj2))
            {
                if (Math.Abs(Convert.ToDouble(obj2) - Convert.ToDouble(obj1)) < tolerance)
                {
                    return true;    //If they are within tolerance
                }
                else
                {
                    return false;   //If they are outside tolerance
                }
            }
            else
            {
                return false;       //If only one is numeric
            }
        }
        //Now assuming both are just random strings
        else
        {
            if ((string)obj1 == (string)obj2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
    // Test whether a given object represents a number
    internal static bool IsNumeric(object ObjectToTest)
    {
        if (ObjectToTest == null)
        {
            return false;
        }
        else
        {
            double OutValue;
            return double.TryParse(ObjectToTest.ToString().Trim(),
                System.Globalization.NumberStyles.Any,
                System.Globalization.CultureInfo.CurrentCulture,
                out OutValue);
        }
    }
    ///
