    void comboBox_Click(object sender, EventArgs e)
    {
        // Calculate cursor position
        Point pointCursorLocal = this.PointToClient(Cursor.Position);
            
        // Calculate rectangle of working area.
        Rectangle rectangle = this.comboBox.Bounds;
        rectangle.Size = new Size(rectangle.Size.Width - 10, rectangle.Height);
        // Check them
        if (rectangle.Contains(pointCursorLocal))
            // CLICK ON WORKING AREA ...
    }
