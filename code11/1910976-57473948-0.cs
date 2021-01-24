    foreach (Microsoft.Office.Interop.Excel.FormatCondition fc in myRange.FormatConditions)
    {
      if (fc.Formula1 == whatever) // You don't need this if statement. bcz you want to delete all of them
      {
        fc.Delete();
      }
    }
