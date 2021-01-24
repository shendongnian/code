    // Thread A:
    _testerStatus = true;                  // tester.SetStatusToTrue();
    Thread.MemoryBarrier();                // Barrier 1
    _testerReleased = true;                // testClassManager.ReleaseTester(tester.Id);
    Thread.MemoryBarrier();                // Barrier 2
    // Thread B:
    Thread.MemoryBarrier();                            // Barrier 3
    if (_testerReleased)                               // foreach (var tester in _releasedTesters)
    {
        Thread.MemoryBarrier();                        //     Barrier 4
        Console.WriteLine($"Status: {_testerStatus}"); //     if (!tester.Value.IsChanged)
    }
