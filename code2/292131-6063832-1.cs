    Application.Current.Dispatcher.Invoke((Action)(() =>
    {
        HomingRobot hb = new HomingRobot();        
        hb.ShowDialog();
    }));
