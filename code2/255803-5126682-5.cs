    Point pA(x,y);
    Point pB(x,y);
    if abs(pB.X-pA.X) < abs(pB.Y-pA.Y) // Going vertically or horizontal?
    {
        DrawLine(pA.X, pA.Y, pA.X, pB.Y); //Long vertical
        DrawLine(pA.X, pB.Y, pB.X, pB.Y); //Short horizontal
    }
    else
    {
        DrawLine(pA.X, pA.Y, pB.X, pA.Y); //Long horizontal
        DrawLine(pB.X, pA.Y, pB.X, pB.Y); //Short vertical
    }
