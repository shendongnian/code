    // DO SOMETHING HERE
    // Add item to ListBox on MainWindow somehow
    if (!mainWindow.Dispatcher.CheckAccess())
        {
           mainWindow.Dispatcher.BeginInvoke(
               System.Windows.Threading.DispatcherPriority.Normal,
               new Action(
                  delegate()
                  {
                    mainWindow.listBox1.Items.Add("hello");                                
                  }));
        }
        else
        {
            mainWindow.listBox1.Items.Add("hello");
        }
