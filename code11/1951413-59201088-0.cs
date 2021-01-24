    class MyClass
    {
        bool _state;
        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == (int)Keys.E)
            {
                writeToPortLaser();
            }
        }
        public void writeToPortLaser()
        {
            _state = !_state; // this toggles the state
            port.Write(_state.ToString());
        }
    }
