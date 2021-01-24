private bool CancelRequired;
SetFormDisabled(true);
Cursor = Cursors.WaitCursor;
CancelRequired = false;
ButtonCancel.Enabled = true;
try
{
  for ( int t = 0; t < MeasNoAvg; t++ )
  {
    if ( CancelRequired ) break;
    Application.DoEvents();
    tempList[t] = AveragePixeLink2();
  }
  temp = tempList.Average();
}
finally
{
  CancelRequired = false;
  ButtonCancel.Enabled = false;
  Cursor = Cursors.Default;
  SetFormDisabled(true);
}
private void ButtonCancel_Click(object sender, EventArgs e)
{
  CancelRequired = true;
}
If the process takes time, you can use a progress bar on the form or in a splash box having TopMost true:
>SplashForm.cs or current form
public void InitProgress(int stepCount, int stepIncrement)
{
  progressBar.Minimum = 0;
  progressBar.Maximum = stepCount;
  progressBar.Value = 0;
  progressBar.Step = stepIncrement;
}
void DoProgress()
{
  progressBar.PerformStep();
  progressBar.Refresh();
  Application.DoEvents();  // Instead of in a loop
}
>Caller form
    SetFormDisabled(true);
    var splash = new SplashForm();
    splash.InitProgress(MeasNoAvg, 1);
    splash.Show();
    CancelRequired = false;
    ButtonCancel.Enabled = true;
    Cursor = Cursors.WaitCursor;
    try
    {
      for ( int t = 0; t < MeasNoAvg; t++ )
      {
        if ( CancelRequired ) break;
        tempList[t] = AveragePixeLink2();
        splash.DoProgress();
      }
      temp = tempList.Average();
    }
    finally
    {
      SetFormDisabled(false);
      CancelRequired = false;
      ButtonCancel.Enabled = false;
      Cursor = Cursors.Default;
      splash.Close();
      SetFormDisabled(false);
    }
Remove the use of splash if the progress bar is in the main form and set progress bar value to 0 at the end.
