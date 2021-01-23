    foreach (RadioButton r in StatusButtonList)
    {
        r.Dispatcher.Invoke(new ThreadStart(() => 
            {
                StatusType status = ((StatusButtonProperties)r.Tag).StatusInformation;
                if (AppLogic.CurrentStatus == null || AppLogic.CurrentStatus.IsStatusNextLogical(status.Code))
                {
                    SolidColorBrush green = new SolidColorBrush(Color.FromRgb(102, 255, 102));
                    r.Background = green;
                }
                else
                {
                    SolidColorBrush red = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    r.Background = red;
                }
            });
    }
