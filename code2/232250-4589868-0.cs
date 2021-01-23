    private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (client.Connected)
            {
                MessageBox.Show("Server is connected, you have to disconect first!", "Conected on server!",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
                e.Cancel = true;
            }     
        }
