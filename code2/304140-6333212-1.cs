    private void InputtedAddress_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.RightButton == MouseButtonState.Pressed)
        {
            thisMenuPlacementTarget = InputtedAddress;
            thisMenu.IsOpen = true;
        }
    }
