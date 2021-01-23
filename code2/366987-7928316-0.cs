    if (this.DroppedDown) {
        // If the comboBox is dropped down
        // Draw the blue rectangle
        e.DrawBackground();
        if (( e.State & DrawItemState.ComboBoxEdit ) == DrawItemState.ComboBoxEdit) {
            // If we are drawing the selected item
            // ...
