    private void MainForm_MouseLeave(object sender, EventArgs e)
        {
    
            this.Cursor = new System.Windows.Forms.Cursor(System.Windows.Forms.Cursor.Current.Handle);
            System.Windows.Forms.Cursor.Position = new Point(0, 0);
            MoveCursor(300, 300);
            MoveCursor(400, 400);
    
        }
        private void MoveCursor(int X, int Y)
        {
            this.Cursor = new System.Windows.Forms.Cursor(System.Windows.Forms.Cursor.Current.Handle);
            System.Windows.Forms.Cursor.Position = new Point(X,Y);
        }
