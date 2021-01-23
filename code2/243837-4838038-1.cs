    private void LayoutRoot_ManipulationCompleted(object sender, ManipulationCompletedEventArgs e)
    {
        if (TouchPanel.IsGestureAvailable)
        {
            if (TouchPanel.ReadGesture().GestureType == GestureType.Tap)
            {
                Debug.WriteLine("A");
            }
        }
    }
