    InputSimulator sim = new InputSimulator();
        
        private void CommandeDataGridView_MouseHover(object sender, EventArgs e)
        {
            sim.Keyboard.KeyDown(WindowsInput.Native.VirtualKeyCode.LCONTROL);
        }
        private void CommandeDataGridView_MouseLeave(object sender, EventArgs e)
        {
            sim.Keyboard.KeyUp(WindowsInput.Native.VirtualKeyCode.LCONTROL);
        }
