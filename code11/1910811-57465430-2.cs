    private void Grid_MouseUp(object sender, MouseButtonEventArgs e)
    {
        // Release the mouse capture and stop tracking it.
        mouseDown = false;
        theGrid.ReleaseMouseCapture();
        // Hide the drag selection box.
        selectionBox.Visibility = Visibility.Collapsed;
        Point mouseUpPos = e.GetPosition(theGrid);
        // TODO: 
        //
        // The mouse has been released, check to see if any of the items 
        // in the other canvas are contained within mouseDownPos and 
        // mouseUpPos, for any that are, select them!
        //
        var buttons = canvasButtons.Children.OfType<System.Windows.Controls.Button>();
        foreach (var button in buttons)
        {
            var isInSelection = IsInsideSelection(mouseDownPos, mouseUpPos, button);
        }
    }
