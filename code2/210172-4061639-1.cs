    public void updateGUI(object state) {
        if (control.InvokeRequired) {
            control.Invoke(new Action<object>(updateGUI), state);
            return;
        }
        // if we are here, we can safely update the GUI
    }
