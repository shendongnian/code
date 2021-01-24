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
So that does not work because of static methods and we have a bad design because of calling TextChanged to change the Text.
Thus here how to do.
Add a static event:
    private static Action CountersUpdated;
Add in the form's Load event:
    CountersUpdated += DoUpdateCounters;
And in the form's FormClosed event:
    CountersUpdated -= DoUpdateCounters;
With:
    private void DoUpdateCounters()
    { 
      cdCounterLBL.Text = CDCreated.ToString();
      lpCounterLBL.Text = LPCreated.ToString();
    }
Now you can write:
private static void CDdirWatcher_Created(object sender, FileSystemEventArgs e)
{ 
  CDCreated++; 
  CallCountersUpdated();
}
private static void LPdirWatcher_Created(object sender, FileSystemEventArgs e)
{ 
  LPCreated++;
  CallCountersUpdated();
}
private static void CallCountersUpdated()
{
  if ( CountersUpdated != null ) CountersUpdated();
}
You can also make two events for CDCounterUpdated and LPCounterUpdated instead of one CountersUpdated.
Have a good job and a good life in C# and OOP.
