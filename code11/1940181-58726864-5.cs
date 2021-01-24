private bool CancelRequired;
Cursor = Cursors.WaitCursor;
Enabled = false;
CancelRequired = false;
ButtonCancel.Enabled = true;
try
{
  for ( int t = 0; t < MeasNoAvg; t++ )
  {
    Application.DoEvents();
    tempList[t] = AveragePixeLink2();
  }
  temp = tempList.Average();
}
finally
{
  CancelRequired = false;
  ButtonCancel.Enabled = false;
  Enabled = true;
  Cursor = Cursors.Default;
}
private void ButtonCancel_Click(object sender, EventArgs e)
{
  CancelRequired = true;
}
If the process takes time, you can use a progress bar or a splash box having one and TopMost true:
>SplashForm.cs
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
    var splash = new SplashForm();
    splash.InitProgress(MeasNoAvg, 1);
    splash.Show();
    CancelRequired = false;
    ButtonCancel.Enabled = true;
    Cursor = Cursors.WaitCursor;
    Enabled = false;
    try
    {
      for ( int t = 0; t < MeasNoAvg; t++ )
      {
        if ( CancelRequired ) 
          break;
        tempList[t] = AveragePixeLink2();
      }
      temp = tempList.Average();
    }
    finally
    {
      CancelRequired = false;
      ButtonCancel.Enabled = false;
      Enabled = true;
      Cursor = Cursors.Default;
      splash.Close();
    }
