    private void OnTimedMousePositionEvent(Object source, ElapsedEventArgs e)
    {
        record.addMousePosition(W,H,MousePosition.X,MousePosition.Y);
    }
    public static void addMousePosition(int w, int h, int x, int y)
    {
        if (x > w/2 && y > h/2)
            mousePositions.Add(1);
         else if (x > w/2 && y <= h/2)
             mousePositions.Add(2);
         else if (x <= w/2 && y <= h/2)
             mousePositions.Add(3);
         else if (x <= w/2 && y > h/2)
             mousePositions.Add(4);
     }
