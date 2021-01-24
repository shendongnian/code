    public async void OnWidgetExecuted()
    {
        await _scanner.ClaimScannerAsync();
        _scanner.Subscribe(OnReceivedBarcode);
    }
    
    // Barcode scanner will call this method when a barcode is received
    private void OnReceivedBarcode(string barcode)
    {
        // update VM accordingly
    }
