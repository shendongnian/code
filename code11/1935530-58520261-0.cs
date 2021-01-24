    void rectangle_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
        ColorDialog colorDialog = new ColorDialog();
        colorDialog.SelectedColor = ((SolidColorBrush)((Rectangle)sender).Fill).Color;
        colorDialog.Owner = this;
        if ((bool)colorDialog.ShowDialog())
        {
            var vm = StatusOEMList.SelectedItem as MyViewModel;
            vm.color = colorDialog.SelectedColor;
        }
    }
