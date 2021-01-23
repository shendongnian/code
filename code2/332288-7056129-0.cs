    class CityAdderForm : Form
    {
        public string NewCity { get; set; }
        private void CityAdderForm _FormClosing(object sender, FormClosingEventArgs e)
        {
            NewCity = // ... any logic that will set the NewCity property.
        }
    }
