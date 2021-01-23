    var del = new Action(foo.Bar);
    del.BeginInvoke(iar =>
    {
       try
       {
          del.EndInvoke(iar);
       }
       catch (Exception ex)
       {
          // Log the message?
       }
    }, null);
