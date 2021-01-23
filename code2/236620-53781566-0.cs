    public static class ModalFileDialog
    {
        /// <summary>
        /// Open this file dialog on top of all other windows
        /// </summary>
        /// <param name="fileDialog"></param>
        /// <returns></returns>
        public static bool? Show(Microsoft.Win32.FileDialog fileDialog)
        {
            Window win = new Window();
            win.ResizeMode = System.Windows.ResizeMode.NoResize;
            win.WindowStyle = System.Windows.WindowStyle.None;
            win.Topmost = true;
            win.Visibility = System.Windows.Visibility.Hidden;
            win.Content = fileDialog;
            bool? result = false;
            win.Loaded += (s, e) =>
            {
                result = fileDialog.ShowDialog();
            };
            win.ShowDialog();
            return result;
        }
    } 
