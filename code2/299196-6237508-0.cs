        Point lastCursorPosition = new Point();
        private void panelPictures_MouseMove(object sender, MouseEventArgs e)
        {
            if (System.Windows.Forms.Cursor.Position != lastCursorPosition)
            {
                Console.WriteLine("mouse moved");
                lastCursorPosition = System.Windows.Forms.Cursor.Position;
            }
            else
            {
                Console.WriteLine("mouse in place");
            }
        }
