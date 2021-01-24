    private void Mouse_Enter(object sender, MouseEventArgs e)
    {
        var element = (UIElement) e.Source;
        var c = Grid.GetColumn(element);
        var r = Grid.GetRow(element);
        if (c == 0 && r == 0)
        {
            MenuButton.Fill = Brushes.Aqua;
        }
    }
    private void Mouse_Leave(object sender, MouseEventArgs e)
    {
        var element = (UIElement) e.Source;
        var c = Grid.GetColumn(element);
        var r = Grid.GetRow(element);
        if (c == 0 && r == 0)
        {
            MenuButton.Fill = Brushes.Black;
        }
    }
