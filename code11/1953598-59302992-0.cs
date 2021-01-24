    private void AddNewTabItem(object sender, MouseButtonEventArgs e)
    {
        ...
        tabControl.Items.Add(ti);
        Dispatcher?.BeginInvoke((Action)(
                () => tabControl.SelectedIndex = tabControl.Items.Count - 1));
    }
