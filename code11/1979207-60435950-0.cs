    private CBCentralManagerState state; 
    public bool CheckBluetoothStatus()
        {
            bool status;
            if (state == CBCentralManagerState.PoweredOn)
            {
                status = true;
                bluetoothEnabledLbl.Text = "Bluetooth enabled";
                bluetoothEnabledAdviceLbl.Text = "Consider turning Bluetooth off if not in use or check to see if all connected devices are recognisable";
            }
            else
            {
                status = false;
                bluetoothEnabledLbl.Text = "Bluetooth not enabled";
            }
                return status;
        }
