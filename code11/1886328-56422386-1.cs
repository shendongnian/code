    public SelectedColor()
    {
        MyCommand = new Command(() =>
        {
            // Change the color
            MainColor = Color.Orange;
        });
    }
    public ICommand MyCommand { set; get; }
