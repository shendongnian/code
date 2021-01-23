    private void Window_MouseDown(object sender, MouseButtonEventArgs e)
    {
    if (e.ChangedButton.Equals(MouseButton.XButton1)) MessageBox.Show(@"back");
    if (e.ChangedButton.Equals(MouseButton.XButton2)) MessageBox.Show(@"forward");
    }
