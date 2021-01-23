    public void TransitionMouseTo(int x, int y, int durationSecs)
    {
        int frames = 10;
        PointF vector = new PointF();
    
        vector.X = (x - Cursor.Position.X) / frames;
        vector.Y = (y - Cursor.Position.Y) / frames;  
            
        for (int i = 0; i < frames; i++)
        {
            Cursor.Position.X += vector.X;
            Cursor.Position.Y += vector.Y;
    
            Thread.Sleep((durationSecs / frames) * 1000);
        }
    }
