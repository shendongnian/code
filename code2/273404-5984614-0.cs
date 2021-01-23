    GuidelineSet guidelines = new GuidelineSet();
    guidelines.GuidelinesX.Add(_bgRect.Left - 0.5);
    guidelines.GuidelinesX.Add(_bgRect.Right + 0.5);
    guidelines.GuidelinesY.Add(_bgRect.Top - 0.5);
    guidelines.GuidelinesY.Add(_bgRect.Bottom + 0.5);
    dc.PushGuidelineSet(guidelines);
    dc.DrawRectangle(Background, _outlinePen, _bgRect);
    if (BorderThickness.Left > 1)
        dc.DrawLine(_leftPen, _bgRect.TopLeft, _bgRect.BottomLeft);
    if (BorderThickness.Top > 1)
        dc.DrawLine(_topPen, _bgRect.TopLeft, _bgRect.TopRight);
    if (BorderThickness.Right > 1)
        dc.DrawLine(_rightPen, _bgRect.TopRight, _bgRect.BottomRight);
    if (BorderThickness.Bottom > 1)
        dc.DrawLine(_bottomPen, _bgRect.BottomRight, _bgRect.BottomLeft);
    dc.Pop();
