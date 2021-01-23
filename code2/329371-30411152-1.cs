    protected override void onShockWaveClick()
        {
            MessageBox.Show("Is this it?\n In Main Form", "AxSHockWave Message");
        }
        protected override void onShockWaveBorderLineMouseMove(int x, int y)
        {
            if (y >= axShockwaveFlash1.Height - 20)
            {
                Text = "Borderline x=" + x.ToString() + " , y = " + y.ToString() + ", ht= " + axShockwaveFlash1.Height;
            }
            else
            {
                Text = "Moving x=" + x.ToString() + " , y = " + y.ToString() + ", ht= " + axShockwaveFlash1.Height;
            }
        }
