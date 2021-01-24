public string EventName
{
  get { return (string)GetValue (EventNameProperty); }
  set { 
        // do something you want
        SetValue (EventNameProperty, value); 
      }
}
