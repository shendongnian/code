    private void DetermineLeftAndRightPoint(Coordinate coordinate1, Coordinate coordinate2)
    {
        Segment seg = new Segment(
          coordinate1, 
          coordinate2, 
          IsParallelToXAxis ? ParallelToAxis.X | ParallelToAxis.None);
    
        LeftPoint = seg.Left;
        RightPoint = seg.Right;
    }
