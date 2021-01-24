    protected override void OnElementChanged(ElementChangedEventArgs<CustomGrid> e)
    {
       if (Control != null)
       {
          Control.BackgroundColor = UIColor.Yellow;
          Control.SetValueForKeyPath(UIColor.Red, (NSString)"textColor");
       }
       
       base.OnElementChanged(e);
    }
