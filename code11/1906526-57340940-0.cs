    private static async void Element_PreviewTouchDown(object sender, TouchEventArgs e)
    {
        var isTouchHold = await TouchHold((FrameworkElement)sender, variableTimespan);
        if (isTouchHold)
        {
            TouchHoldCmd?.Execute(someParam);
            e.Handled = true;
        }
    }
