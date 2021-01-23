    while (true) {
        if(DateTime.Now.Subtract(_lastExecuteTime).TotalHours > 1) {
            DoWork();
            _lastExecuteTime = DateTime.Now();
            continue; 
        }
        if (terminate.WaitOne(10000)) {
            break;
        }
    }
