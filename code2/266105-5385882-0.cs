        [DllImport("dwmapi.dll", PreserveSig = false)]
        public static extern bool DwmIsCompositionEnabled();
        public bool IsAeroActive()
        {
            // Check if Aero is enabled;
            if (DwmIsCompositionEnabled())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            bool aeroEnabled = IsAeroActive();
            if (aeroEnabled)
            {
                MessageBox.Show("Aero is enabled.");
            }
            else
            {
                MessageBox.Show("Aero is disabled.");
            }
        }
