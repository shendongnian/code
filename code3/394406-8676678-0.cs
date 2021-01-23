    for(double opacity = 0.0; opacity <= 1.0; opacity += 0.2) {
        DateTime start = DateTime.Now;
        this.Opacity = opacity;
    
        while(DateTime.Now.Subtract(start).TotalMilliseconds <= 30.0) {
            Application.DoEvents();
        }
    }
