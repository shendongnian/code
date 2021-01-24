    // Thread A:
    _testerStatus = true;                  // tester.SetStatusToTrue();
    _testerReleased = true;                // testClassManager.ReleaseTester(tester.Id);
    // Thread B:
    if (_testerReleased)                               // foreach (var tester in _releasedTesters)
        Console.WriteLine($"Status: {_testerStatus}"); //     if (!tester.Value.IsChanged)
