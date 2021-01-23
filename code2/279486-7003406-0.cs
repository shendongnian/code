        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            timerFill.Enabled = checkBox2.Checked;
        }
        private void timerFill_Tick(object sender, EventArgs e)
        {
            GenerateSquareWave();
        }
        int const bufferSize = 256;
        void GenerateSquareWave()
        {
            int k = serialPort1.BytesToWrite;
            label11.Text = k.ToString();
            if (k < bufferSize)
            {
                byte[] data = new byte[bufferSize];
                for (int i = 0; i < bufferSize; i++)
                {
                    data[i] = 0xAA;
                }
                serialPort1.BaseStream.BeginWrite(data, 0, data.Length, new AsyncCallback((IAsyncResult ar) => serialPort1.BaseStream.EndWrite(ar)), null);
            }
        }
