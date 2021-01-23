    public void TransitionMouseTo(int x, int y, int durationSecs)
    {
        int frames = 10;
        PointF vector = new PointF();
    
        vector.X = (x - Cursor.Position.X) / frames;
        vector.Y = (y - Cursor.Position.Y) / frames;  
            
        for (int i = 0; i < frames; i++)
        {
            Point pos = Cursor.Position;
            pos.X += vector.X;
            pos.Y += vector.Y;
            Cursor.Position = pos;
    
            Thread.Sleep((durationSecs / frames) * 1000);
        }
    }
