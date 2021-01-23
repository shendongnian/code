    Point pA=(x,y);
    Point pB=(x,y)
    if abs(pB.X-pA.X) < abs(pB.Y-pA.Y) // Going vertically or horizontal?
    {
    DrawLine(pA.X, pA.Y, pA.X, pB.Y/2); //Long vertical 1st half
    DrawLine(pA.X, pB.Y/2, pB.X, pB.Y/2); //Short horizontal
    DrawLine(pA.X, pA.Y/2, pA.X, pB.Y); //Long vertical 2nd half
    }
    else
    {
    DrawLine(pA.X, pA.Y, pB.X/2, pA.Y); //Long horizontal 1st Half
    DrawLine(pB.X/2, pA.Y, pB.X/2, pB.Y); // Short Vertical
    DrawLine(pA.X/2, pA.Y, pA.X, pB.Y); //Long horizontal 2nd half
    }
