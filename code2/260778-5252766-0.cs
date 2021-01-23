    private void Go()
    {
        while (btn.Location.X < this.Size.Width - btn.Size.Width)
        {
            Invoke(new moveBd(moveButton), button1);
            Thread.Sleep(100);
        }
    }
