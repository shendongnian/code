    using (var processes = System.Diagnostics.Process.GetProcesses().AsDisposable()) {
        foreach (var p in processes.Enumerable) {
            Console.Write(p.Id);
        }
    }
