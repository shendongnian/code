    private void RevisedQueueFloodFill(Point node, Color targetColor, Color replaceColor)
    {
        if (pixels[node.X, node.Y].CellColor != targetColor) return;
        Queue<Point> Q = new Queue<Point>();
        Q.Enqueue(node);
        while (Q.Count != 0)
        {
            Point n = Q.Dequeue();
            if (pixels[n.X, n.Y].CellColor == targetColor)
            {
                int y = n.Y;
                int w = n.X;
                int e = n.X;
                while (w > 0 && pixels[w - 1, y].CellColor == targetColor) w--;
                while (e < CANVAS_SIZE - 1 && pixels[e + 1, y].CellColor == targetColor) e++;
                for (int x = w; x <= e; x++)
                {
                    pixels[x, y.CellColor] = replaceColor;
                    if (y > 0 && pixels[x, y - 1].CellColor == targetColor)
                    {
                        Q.Enqueue(new Point(x, y - 1));
                    }
                    if (y < CANVAS_SIZE - 1 && pixels[x, y + 1].CellColor == targetColor)
                    {
                        Q.Enqueue(new Point(x, y + 1));
                    }
                }
            }
        }
    }
