    var worksheet = (Worksheet)Globals.ThisAddIn.Application.ActiveSheet;
         var cell = (Range)worksheet.Cells[1, 1];
         cell.Validation.Add(
            XlDVType.xlValidateList, 
            XlDVAlertStyle.xlValidAlertStop, 
            XlFormatConditionOperator.xlBetween,
            "A, B, C, D, E");
