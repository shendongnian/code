    private Random random = new Random();
    
    public async Task DoStuff()
    {
        int min = 0;
        int max = 255;
        for ( int i = 0; i < 10; i++ )
        {
           label12.Text = random.Next(min, max + 1);
           await Task.Delay(100); 
        }
    }
