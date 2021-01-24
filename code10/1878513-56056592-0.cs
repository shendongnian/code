    int seconds = 2;
    if (seconds < 1) return;
    DateTime _desired = DateTime.Now.AddSeconds(seconds);
    while (DateTime.Now < _desired)
    {
       System.Windows.Forms.Application.DoEvents();
       //do whatever you want in this 2 seconds
    }
