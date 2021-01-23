    public class SetScanHistoryEvents: EventArgs
    {
        public SetScanHistoryEvents(string text)
        {
            this.Text = text;
        }
    
        public string Text { get; set; }
    }
    
    public class Scan
    {
        public event EventHandler<SetScanHistoryEvents> ScanHistoryEvent;
    
        // Sets the text of scan history in the ui
        private void SetScanHistory(string text)
        {
            if (this.ScanHistoryEvent != null)
            {
                this.ScanHistoryEvent(this, new SetScanHistoryEvents(text));
            }
        }
    }
