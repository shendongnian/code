        private void Form1_Load(object sender, EventArgs e)
        {
            var systemSounds = new[]
                                  {
                                      System.Media.SystemSounds.Asterisk,
                                      System.Media.SystemSounds.Beep,
                                      System.Media.SystemSounds.Exclamation,
                                      System.Media.SystemSounds.Hand,
                                      System.Media.SystemSounds.Question
                                  };
            comboBox1.DataSource = systemSounds;
            comboBox1.SelectedIndexChanged += new EventHandler(comboBox1_SelectedIndexChanged);
        }
        void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ((System.Media.SystemSound)comboBox1.SelectedItem).Play();
        }
