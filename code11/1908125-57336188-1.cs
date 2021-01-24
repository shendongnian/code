    box.MouseEnter += OpenContextMenuOnMouseMove;
    
    // Opening the ContextMenu will trigger the MouseLeave event. So closing it will raise the MouseEnter event again (infinite loop).
    // Solution: unhook from MouseEnter event until the ContextMenu was closed
    box.ContextMenu.Opened += (s, e) => this.TextBox.MouseEnter -= OpenContextMenuOnMouseMove;
    box.ContextMenu.Closed += (s, e) =>
    {  
      box.Focus();
      box.CaretIndex = this.TextBox.Text.Length;
      box.MouseEnter += OpenContextMenuOnMouseMove;
    };
    private void OpenContextMenuOnMouseMove(object sender, MouseEventArgs mouseEventArgs) => this.TextBox.ContextMenu.IsOpen = true;
