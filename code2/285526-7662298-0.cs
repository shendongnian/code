    //Point the mouse for drag
    
    Mouse.Instance.Location = draggedItem.ClickablePoint;
    
    Mouse.LeftDown();
    
    //Move the mouse a little down
    Mouse.Instance.Location = new Point(draggedItem.ClickablePoint.X, draggedItem.ClickablePoint.Y + 1);
    
    //Move to the new window
    targetWindow.Focus();
    
    //Set the point to drop
    Mouse.Instance.Location = targetWindow.ClickablePoint;
    
    //Drop
    Mouse.LeftUp();
