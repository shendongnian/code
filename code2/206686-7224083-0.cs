        ///<summary>
        /// Show help from the resources for a particular control by contextGUID
        ///</summary>
        ///<param name="contextGUID"></param>
        private void ShowApplicationHelp(string contextGUID = "1")
        {
          
            if (HelpWin != null)
            {
                if (HelpWin.IsOpen)
                {
                    HelpWin.BringToFront();
                    return;
                }
            }
            HelpWin = new MigratorHelpWindow();
            HelpWin.Owner = Application.Current.MainWindow;
            HelpWin.ResizeMode = ResizeMode.CanResizeWithGrip;
            HelpWin.Icon = new Image()
                               {
                                   Source =
                                       new BitmapImage(
                                       new Uri(
                                           "pack://application:,,,/ResourceLibrary;component/Resources/Images/Menu/Help.png",
                                           UriKind.RelativeOrAbsolute))
                               };
            HelpWin.Show();
            HelpWin.BringToFront();
        }
