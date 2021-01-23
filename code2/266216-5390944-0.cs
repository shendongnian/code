    public class DataContainer
    {
        public event EventHandler AcceptedChanges;
        protected virtual void OnAcceptedChanges()
        {
            if ((this.AcceptedChanges != null))
            {
                this.AcceptedChanges(this, EventArgs.Empty);
            }
        }
        public void AcceptChanges()
        {
            this.OnAcceptedChanges();
        }
        public string Text1 { get; set; }
        public string Text2 { get; set; }
    }
