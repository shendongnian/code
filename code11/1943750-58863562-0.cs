        bool _oldSignal = false;
        private void timer3_Tick(object sender, EventArgs e)
        {
            bool newSignal = chksignal_robot(); //keep checking signal      
            bool isRisingEdge = newSignal && (_oldSignal == false);
            _oldSignal = newSignal;
            if (textBox8.Text.Contains("process") && isRisingEdge) //
            {
                totalsheetcount++;
                grab_image();
                Thread.Sleep(200);
                processimage();
            }
        }
