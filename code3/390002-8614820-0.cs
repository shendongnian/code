        public static void Grab(int xPos, int yPos)
        {
            _dragging = true;
           
            Cursor.Position = new Point(xPos, yPos + offSet);
            mouse_event(leftDown, (uint) xPos, (uint) yPos, 0, 0);
            var t = new Thread(CheckMouseStatus);
            t.Start();
        }
        public static void Release(int xPos, int yPos)
        {
            _dragging = false;
            Cursor.Position = new Point(xPos, yPos + offSet);
            mouse_event(leftUp, (uint) xPos, (uint) yPos, 0, 0);
        }
        private static void CheckMouseStatus()
        {
            do
            {
                Cursor.Position = new Point(KinectSettings.movement.HandX, KinectSettings.movement.HandY + offSet);
            } 
            while (_dragging);
        }
