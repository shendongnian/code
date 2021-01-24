    private Random _rand = new Random();
    private bool _stop;
    private async void Button1_StartClick(...)
    {
        _stop = false;
        while(!_stop)
        {
            label1.Text = _rand.Next(1, 7);
            await Task.Delay(500);
        }
    }
    private void Button1_StopClick(...)
      => _stop = true;
