    private void RemoveControl()
    {
       name = myUserControl.GetValue(NameProperty).ToString();               
       myCanvas.Children.Remove(myUserControl);
       NameScope.GetNameScope(this).UnregisterName(name);
    }
