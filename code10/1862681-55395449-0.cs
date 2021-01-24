    private bool isBreaked=false;
    
    private void MetroContentControl_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
    {
        if(!isBreaked)
        {
            if ((bool)e.NewValue == true)
            {
              // goes visible
            }
            else
            {
              // hide it!
              if (myCondition == true)
              {
                // here I wish break the hide event and mantain the user control visible
                isBreaked = true;
              }
            }
        }
    }
