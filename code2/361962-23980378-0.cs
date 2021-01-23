    // On the form's MouseLeave event, please checking for mouse position is not in each control's client area.
        private void TheForm_MouseLeave(object sender, EventArgs e)
        {
            bool mouse_on_control = false;
            foreach (Control c in Controls)
                mouse_on_control |= c.RectangleToScreen(c.ClientRectangle).Contains(Cursor.Position);
            if (!mouse_on_control)
                Close();
        }
    // And in addition, if any control inside has its client area overlapping the form's client area at any border, 
    // please also checking if mouse position is outside the form's client area on the control's MouseLeave event.
        private void ControlOverlappedTheFormsBorder_MouseLeave(object sender, EventArgs e)
        {
            if (!RectangleToScreen(ClientRectangle).Contains(Cursor.Position))
                Close();
        }
