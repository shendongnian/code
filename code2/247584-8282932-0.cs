    public unsafe System.Drawing.Point GetClientCurorPos(IntPtr hWnd, Point*p)
    {
        Point p = new Point();
        if (GetCursorPos(&p))
        {
           ScreenToClient(hWnd, &p);
        }
        return p;
    }
