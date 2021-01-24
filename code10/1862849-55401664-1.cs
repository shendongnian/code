    public static void addMousePosition(Point mousePosition)
    {
        if (topLeft.Contains(mousePosition))
            mousePositions.Add(1);
        else if (topRight.Contains(mousePosition))
            mousePositions.Add(2);
        else if (bottomLeft.Contains(mousePosition))
            mousePositions.Add(3);
        else if (bottomRight.Contains(mousePosition))
            mousePositions.Add(4);
    }
