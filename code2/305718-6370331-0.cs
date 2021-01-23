    class RowHolderEventArgs : EventArgs
    {
        public DataRow row;
        public RowHolderEventArgs(DataRow row)
        {
            this.row = row;
        }
    };
    public delegate void RowHolderEvent(object sender, RowHolderEventArgs e);
    class RowHolder
    {
        public event RowHolderEvent Elapsed;
        DataRow row;
        public RowHolder(DataRow row, Timer timer)
        {
            this.row = row;
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);
        }
        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (this.Elapsed != null)
            {
                Elapsed(sender, new RowHolderEventArgs(row));
            }
        }
    }
