    foreach (var kid in ((MainWindow)App.Current.Windows[0]).MainCanvas.Children)
    {
        string kidType = kid.GetType().FullName;
        if (kidType.EndsWith("MyUserControl"))
        {
             UserControl myUserControl = (UserControl)kid;
             if (myUserControl is MyUserControlClass)
             {
                 (myUserControl as MyUserControlClass).Hide();
             }
        }
    }
