private bool CancelRequired;
SetFormEnabled(false);
Cursor = Cursors.WaitCursor;
CancelRequired = false;
ButtonCancel.Enabled = true;
try
{
  for ( int t = 0; t < MeasNoAvg; t++ )
  {
    if ( CancelRequired ) break;
    tempList[t] = AveragePixeLink2();
    Refresh();
    Application.DoEvents();
  }
  temp = tempList.Average();
}
finally
{
  CancelRequired = false;
  ButtonCancel.Enabled = false;
  Cursor = Cursors.Default;
  SetFormEnabled(true);
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
}
>Caller form
    SetFormEnabled(false);
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
        Refresh();
        splash.DoProgress();
        Application.DoEvents();
      }
      temp = tempList.Average();
    }
    finally
    {
      CancelRequired = false;
      ButtonCancel.Enabled = false;
      Cursor = Cursors.Default;
      splash.Close();
      SetFormEnabled(true);
    }
Remove the use of splash if the progress bar is in the main form and set progress bar value to 0 at the end.
