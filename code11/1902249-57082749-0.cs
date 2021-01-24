        ...
        if (i == 200)
        {
           a.StrokeThickness = 2;
           b.StrokeThickness = 2;
           a.MouseLeftButtonDown += A_MouseLeftButtonDown;
        }
    }
    canGraph.MouseLeftButtonUp += CanGraph_MouseLeftButtonUp;
    canGraph.MouseMove += CanGraph_MouseMove;
