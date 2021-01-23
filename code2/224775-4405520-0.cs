    private SoundPlayer player = new SoundPlayer();
    /// Button click event handler.
    private void AsyncBtn_Click(object sender, EventArgs e)
    {
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            // Set .wav file as TextBox.Text.
            textBox1.Text = openFileDialog1.FileName;
            // Add LoadCompleted event handler.
            player.LoadCompleted += new AsyncCompletedEventHandler(LoadCompleted);
            // Set location of the .wav file.
            player.SoundLocation = openFileDialog1.FileName;
            // Load asynchronously.
            player.LoadAsync();
        }
    }
    /// LoadCompleted event handler.
    private void LoadCompleted(object sender, AsyncCompletedEventArgs args)
    {
        player.Play();
    }
