private DateTime _lastWriteTime = DateTime.Now;
private void OverwriteText()
{
    if ((DateTime.Now - _lastWriteTime).TotalMinutes > 2)
    {
        string txt = Convert.ToString(TotCostLong);
        File.WriteAllText("total-cost.txt", txt);
        _lastWriteTime = DateTime.Now;
    }
}
private void timer1_Tick(object sender, EventArgs e)
{
    OverwriteText();
}
