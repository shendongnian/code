    public void setScreenSize()
    {
        this.W = Screen.PrimaryScreen.Bounds.Width;
        this.H = Screen.PrimaryScreen.Bounds.Height;
        Console.WriteLine("Height is: " + this.H + "width is: " + this.W);
    }
