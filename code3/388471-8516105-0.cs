        public string ConnString { get; set; }
        private void Form1_Load(object sender, EventArgs e)
        {
            ConnString = ConfigurationSettings.AppSettings["sampleconnectionstring"];
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 0)
            {
                ConnString = ConfigurationSettings.AppSettings["sampleconnectionstring"];
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                ConnString = ConfigurationSettings.AppSettings["sampleconnectionstring1"];
            }
            else if (comboBox1.SelectedIndex == 2)
            {
                ConnString = ConfigurationSettings.AppSettings["sampleconnectionstring2"];
            }
            else if (comboBox1.SelectedIndex == 3)
            {
                ConnString = ConfigurationSettings.AppSettings["sampleconnectionstring3"];
            }
        }
