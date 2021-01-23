    Queue<Process> ProcessesToRun = new Queue<Process>(new []{ new Process("1"), new Process("2"), new Process("3") });
    
    void ProcessExited(object sender, System.EventArgs e) {
        GrabNextProcessAndRun();
    }
    
    void GrabNextProcessAndRun() {
        if (ProcessesToRun.Count > 0) {
            Process process = ProcessesToRun.Dequeue();
            process.Exited += ProcessExited;
            process.Start();
        }
    }
    
    void TheEntryPoint() {
        GrabNextProcessAndRun();
    }
