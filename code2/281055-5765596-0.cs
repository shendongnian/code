        event EventHandler IDrawingObject.OnDraw
        {
            add
            {
                lock (PreDrawEvent)
                {
                    PreDrawEvent += value;
                }
                YourFunction();  // HERE
            }
