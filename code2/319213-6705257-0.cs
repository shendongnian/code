    public void ReceivesIncomingTCP(DateTime startDate)
    {
    Thread.Sleep(startDate.Subtract(DateTime.Now).Milliseconds)
    DoAction();
    }
