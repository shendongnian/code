DateTime startUtc;
 
private void ScanpXRF()
{
  startUtc = DateTime.NowUtc;
  (...)
  //START action to be measured here!
}
private static void pXRFTimer_Tick(Object sender, EventArgs e)
{
  var elapsed = DateTime.NowUtc - startUtc;
  var elapsedSeconds = elapsed.TotalSeconds; // double so you may want to round.
}
