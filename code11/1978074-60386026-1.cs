    {
    Microsoft.Office.Interop.Access.Application AccessApp = 
      new Microsoft.Office.Interop.Access.Application();
    AccessApp.OpenCurrentDatabase(@"c:\test\test44.accdb");
    AccessApp.Run("MyLinker");
    AccessApp.CloseCurrentDatabase();
    AccessApp.Quit();
    }
