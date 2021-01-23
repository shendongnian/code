    public delegate void ppmmEventHandler(ppmmEventArgs e);
    public class ppmmEventArgs : EventArgs
    {
        public ppmmEventArgs(double? oldFactor, double? newFactor)
        {
            OldFactor = oldFactor;
            NewFactor = newFactor;
        }
        public double? OldFactor { get; private set; }
        public double? NewFactor { get; private set; }
    }
