    private void KeepAlive()
    {
        var dummy = _context.BankAccounts.AsNoTracking().ToList().Count;
        Console.WriteLine($@"{DateTime.Now} KeepAlive");
    }
