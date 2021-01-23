    // set this to new object() in the constructor
    public object CloseMonitor { get; private set; }
    public bool HasBeenClosed { get; private set; }
    private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
        lock (this.CloseMonitor) {
            this.HasBeenClosed = true;
            // other code
        }
    }
