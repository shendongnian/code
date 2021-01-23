    bool IsMouseHover(Control c, Control container)
            {
                Point p = Control.MousePosition;
                Point p1 = c.PointToClient(p);
                Point p2 = container.PointToClient(p);
                if (c.DisplayRectangle.Contains(p1) && container.DisplayRectangle.Contains(p2))
                {
                    return true;
                }
                return false;
            }
