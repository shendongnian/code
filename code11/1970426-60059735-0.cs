    public async Task<string> Scan()
    {
        var options = new ZXing.Mobile.MobileBarcodeScanningOptions
        {
            PossibleFormats = new List<ZXing.BarcodeFormat>
            {
                ZXing.BarcodeFormat.QR_CODE
            },
            TryHarder = false,
            AutoRotate = false,
            TryInverted = false,
        };
        scanPage = new ZXingScannerPage();
        scanPage.AutoFocus();
        using (SemaphoreSlim semaphoreSlim = new SemaphoreSlim(0, 1))
        {
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.Navigation.PopAsync();
                    try
                    {
                        Result = result.Text;
                    }
                    catch (Exception ex)
                    {
                        Result = ex.Message;
                    }
                    semaphore.Release();
                });
            };
            await Application.Current.MainPage.Navigation.PushAsync(scanPage);
            await semaphoreSlim.WaitAsync();
        }
        return Result;
    }
