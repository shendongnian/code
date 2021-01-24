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
So here we have a bad design because of calling TextChanged to change the Text.
Thus here how to do:
private static void CDdirWatcher_Created(object sender, FileSystemEventArgs e)
{ 
  CDCreated++; 
  UpdateCounters();
}
private static void LPdirWatcher_Created(object sender, FileSystemEventArgs e)
{ 
  LPCreated++;
  UpdateCounters();
}
private void UpdateCounters()
{ 
  cdCounterLBL.Text = CDCreated.ToString();
  lpCounterLBL.Text = LPCreated.ToString();
}
You can also make two methods UpdateCounterCD and UpdateCounterLP instead of one UpdateCounters.
Have a good job and a good life in C# and OOP.
