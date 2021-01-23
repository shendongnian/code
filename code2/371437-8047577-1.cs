    // Use the panelDraw paint event to draw shapes that are done
    void panelDraw_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = panelDraw.CreateGraphics();
        
        foreach (Rectangle shape in listOfShapes)
        {
            shape.Draw(g);
        }
    }
    
    // Use the panelArea_paint event to update the new shape-dragging...
    private void panelArea_Paint(object sender, PaintEventArgs e)
    {
        Graphics g = panelArea.CreateGraphics();
    
        if (drawSETPaint == true)
        {
            Pen p = new Pen(Color.Blue);
            p.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
    
            if (IsShapeRectangle == true)
            {
                g.DrawRectangle(p, rect);
            }
            else if (IsShapeCircle == true)
            {
                g.DrawEllipse(p, rect);
            }
            else if (IsShapeLine == true)
            {
                g.DrawLine(p, startPoint, endPoint);
            }
        }
    }
    
    private void panelArea_MouseUp(object sender, MouseEventArgs e)
    {
    
        endPoint.X = e.X;
        endPoint.Y = e.Y;
    
        drawSETPaint = false;
    
        if (rect.Width > 0 && rect.Height > 0)
        {
            if (IsShapeRectangle == true)
            {
                listOfShapes.Add(new TheRectangles(rect, currentColor, currentBoarderColor, brushThickness));
            }
            else if (IsShapeCircle == true)
            {
                listOfShapes.Add(new TheCircles(rect, currentColor, currentBoarderColor, brushThickness));
            }
            else if (IsShapeLine == true)
            {
                listOfShapes.Add(new TheLines(startPoint, endPoint, currentColor, currentBoarderColor, brushThickness));
            }
    
            panelArea.Invalidate();
        }
    	
    	panelDraw.Invalidate();
    }
