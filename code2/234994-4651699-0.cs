        public static void LeftClick(int x, int y)
        {
            Cursor.Position = new System.Drawing.Point(x, y); //<= fails without this
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }
