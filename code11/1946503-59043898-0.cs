    Microsoft.Office.Interop.Excel.FormatCondition format7 = (Microsoft.Office.Interop.Excel.FormatCondition)(uiWorksheet.get_Range("B7:Z" + headercount,
    Type.Missing).FormatConditions.Add(Microsoft.Office.Interop.Excel.XlFormatConditionType.xlExpression, Microsoft.Office.Interop.Excel.XlFormatConditionOperator.xlEqual,
    "=INDIRECT(\"V\"&ROW())=\"No\"", Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing));
    
    format7.Interior.Color = System.Drawing.Color.Gray;
