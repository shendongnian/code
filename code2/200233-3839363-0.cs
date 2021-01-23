    if (e.Index < 0)
        return;
    
    Brush foreBrush = Brushes.Black; // non-selected text color
    if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
    {
        foreBrush = Brushes.White; // selected text color
        e = new DrawItemEventArgs(e.Graphics,
                                  e.Font,
                                  e.Bounds,
                                  e.Index,
                                  e.State ^ DrawItemState.Selected,
                                  e.ForeColor,
                                  Color.Red); // Choose the color 
    }
    
    // Draw the background of the ListBox control for each item. 
    e.DrawBackground();
    // Draw the current item text
    e.Graphics.DrawString((sender as ListBox).Items[e.Index].ToString(), e.Font, foreBrush, e.Bounds, StringFormat.GenericDefault);
    // If the ListBox has focus, draw a focus rectangle around the selected item. 
    e.DrawFocusRectangle(); 
