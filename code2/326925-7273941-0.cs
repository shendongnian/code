    private void RevisedQueueFloodFill(Point node, Color replaceColor)
    {
        Color targetColor = pixels[node.X, node.Y].CellColor;
        if (targetColor == replaceColor) return;
        Queue<Point> q = new Queue<Point>();
        q.Enqueue(node);
        Point n, t, u;
        while (q.Count > 0)
        {
            n = q.Dequeue();
            if (pixels[n.X, n.Y].CellColor == targetColor)
            {
                t = n;
                while ((t.X > 0) && (pixels[t.X, t.Y].CellColor == targetColor))
                {
                    pixels[t.X, t.Y].CellColor = replaceColor;
                    t.X--;
                }
                int XMin = t.X + 1;
                t = n;
                t.X++;
                while ((t.X < CANVAS_SIZE - 1) &&
                       (pixels[t.X, t.Y].CellColor == targetColor))
                {
                    pixels[t.X, t.Y].CellColor = replaceColor;
                    t.X++;
                }
                int XMax = t.X - 1;
                t = n;
                t.Y++;
            
                u = n;
                u.Y--;
                for (int i = XMin; i <= XMax; i++)
                {
                    t.X = i;
                    u.X = i;
                    if ((t.Y < CANVAS_SIZE - 1) &&
                        (pixels[t.X, t.Y].CellColor == targetColor)) q.Enqueue(t);
                    if ((u.Y >= 0) &&
                        (pixels[u.X, u.Y].CellColor == targetColor)) q.Enqueue(u);
                }
            }
        }
    }
