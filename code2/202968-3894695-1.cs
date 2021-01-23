        float tickCount = 0.0f;
        float tickDelta = 1000.0f / 60.0f;
        void mmTimer_Tick(object sender, EventArgs e)
        {
            tickCount++;
            if (tickCount >= tickDelta)
            {
                tickCount -= tickDelta;
                // scroll your text here 
                Invalidate();
            }
        }
    will do.
