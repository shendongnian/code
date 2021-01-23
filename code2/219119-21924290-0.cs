    var cell = ... // Get the cell
    if (cell != null)
    {
         BeginInvoke(new MethodInvoker(() =>
         {
              cell.Activate();
              bugGrid.PerformAction(UltraGridAction.EnterEditMode);
         }));
    }
