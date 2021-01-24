public bool IsPairingConfirmed(Android.Bluetooth.BluetoothDevice device)
{
    bool confirmation = false;
    try
    {
        if ((int)Android.OS.Build.VERSION.SdkInt >= 19)
            confirmation = device.SetPairingConfirmation(true);
    }
    catch(Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    return confirmation;
}
I hope this makes sense, and make sure you do everything else right. 
