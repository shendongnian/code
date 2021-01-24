private static void CDdirWatcher_Created(object sender, FileSystemEventArgs e)
{ 
  CDCreated += 1; 
  cdCounterLbl_TextChanged(this, null);
}
private static void LPdirWatcher_Created(object sender, FileSystemEventArgs e)
{ 
  LPCreated += 1;
  lpCounterLbl_TextChanged(this, null);
}
private void cdCounterLbl_TextChanged(object sender, EventArgs e)
{ 
  cdCounterLBL.Text = CDCreated.ToString();
}
private void lpCounterLbl_TextChanged(object sender, EventArgs e)
{
  lpCounterLBL.Text = LPCreated.ToString();
}
Have a good job and a good life in C# and OOP.
