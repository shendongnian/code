    public delegate void DataAddedEventHandler(object sender, EventArgs e);
        public partial class FormA : Form
        {
        public event DataAddedEventHandler DataAdded;
        private void AddButton_Click(object sender, EventArgs e)
        {
            //do The database stuff...
            //fire the event
            OnDataAdded();
        }
        private void OnDataAdded()
        {
            if (DataAdded != null)
            {
                DataAdded(this, new EventArgs());
            }
        }
