    SolidColorBrush blueBrush = new SolidColorBrush(Colors.Blue)
    SolidColorPen bluePen = new SolidColorPen(blueBrush)
    
    for (int i = 0; i < MaxRow; i++)
    {
        for (int j = 0; j < MaxColumn; j++)
        {
            dc.DrawRectangle(blueBrush, bluePen, 1), new Rect(j * cellSize , i * cellSize , cellSize - 1, cellSize - 1));
        }
    }
    
