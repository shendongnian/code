    r.Dispatcher.Invoke(new Action(delegate()
    {
        status = ((StatusButtonProperties)r.Tag).StatusInformation;
        if (AppLogic.CurrentStatus == null || AppLogic.CurrentStatus.IsStatusNextLogical(status.Code))
        {
            r.Background = Brushes.Green;
        }
        else
        {
            r.Background = Brushes.Red;
        }
    }));
