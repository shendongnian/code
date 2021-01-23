    System.Windows.Forms.DialogResult result = new System.Windows.Forms.DialogResult();
    Window win = new Window();
    win.ResizeMode = System.Windows.ResizeMode.NoResize;
    win.WindowStyle = System.Windows.WindowStyle.None;
    win.Topmost = true;
    win.Visibility = System.Windows.Visibility.Hidden;
    win.Owner = this.shell;
    win.Content = saveFileDialog;
    win.Loaded += (s, e) =>
    {
        result = saveFileDialog.ShowDialog();
    };
    win.ShowDialog();
    return result;
}
