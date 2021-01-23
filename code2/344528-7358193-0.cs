    var hook = new KeyboardHook();
    var availbleScanners = KeyboardHook.GetKeyboardDevices();
    ... // find out which scanner to use 
    hook.SetDeviceFilter(availableScanners.First());
    hook.KeyPressed += OnBarcodeKey;
    hook.AddHook(YourWPFMainView);
    ...
    public void OnBarcodeKey(object sender, KeyPressedEventArgs e) {
        Console.WriteLine("received " + e.Text);
    }
