      using System.Linq;
      ... 
      // Close the last opened EmployeeInfoPopup if it exists
      Application
        .OpenForms
        .OfType<EmployeeInfoPopup>()
        .LastOrDefault()
       ?.Close();
