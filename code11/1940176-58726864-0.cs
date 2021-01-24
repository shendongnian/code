    Cursor = Cursors.WaitCursor;  // for UX
    Enabled = false;              // for UX
    try
    {
      for ( int t = 0; t < MeasNoAvg; t++ )
      {
        Application.DoEvents();   // for UI
        tempList[t] = AveragePixeLink2();
      }
      temp = tempList.Average();
    }
    finally
    {
      Enabled = true;
      Cursor = Cursors.Default;
    }
