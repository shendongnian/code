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
    private static Action UpdateCounters;
Add in the form instance constructor after InitializeComponents:
    UpdateCounters += DoUpdateCounters;
And in the destructor:
    UpdateCounters -= DoUpdateCounters;
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
  CallUpdateCounters();
}
private static void LPdirWatcher_Created(object sender, FileSystemEventArgs e)
{ 
  LPCreated++;
  CallUpdateCounters();
}
private static void CallUpdateCounters()
{
  if (UpdateCounters != null) UpdateCounters();
}
You can also make two events for UpdateCounterCD and UpdateCounterLP instead of one UpdateCounters.
Have a good job and a good life in C# and OOP.
