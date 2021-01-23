    public class Form2
    {
        private readonly Action _ammountUpdater;
        public Form2(Action ammountUpdater)
        {
            _ammountUpdater = ammountUpdater;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            _ammountUpdater(); // now this updates the existing form1 instance
            this.Close();
        }
    }
