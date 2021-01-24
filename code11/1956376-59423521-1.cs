public string MessageString 
{
  get { return (string)GetValue (MessageStringProperty ); }
  set { 
        // do something you want
        SetValue (MessageStringProperty, value); 
      }
}
