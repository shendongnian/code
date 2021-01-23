    private Timer timer;
    
    private void someMethod()
    {
        var d = new Dictionary<string, int>
                    {
                        {"cat", 22}, 
                        {"dog", 14}, 
                        {"llama", 2}, 
                        {"iguana", 6}
                    };
    
        int index = 0;
        TimerCallback timerCallBack = state =>
                                            {
                                                DisplayText(d.ElementAt(index).Key, d.ElementAt(index).Value);
                                                if(++index == d.Count)
                                                {
                                                    index = 0;
                                                }
                                            };
        timer = new Timer(timerCallBack, null, TimeSpan.Zero, TimeSpan.FromSeconds(3));
    }
    
    private void DisplayText(string x, int y)
    {
        label1.Text = x;
        int someValue= 3+y;
    }
