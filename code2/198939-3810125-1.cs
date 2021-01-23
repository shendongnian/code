    private Excel.Worksheet GetWorksheetByName(string name)
    {
      foreach (Excel.Worksheet worksheet in this.Worksheets)
      {
        if (worksheet.Name == name)
        {
          return worksheet;
        }
      }
      throw new ArgumentException();
    }
    
    private void ActivateWorksheetByName(string name)
    {
      GetWorksheetByName(name).Activate();
    }
