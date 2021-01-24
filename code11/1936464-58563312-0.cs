        ZXingScannerPage scanPage;
        SendData sd;
        private async void Btnpe001_Clicked(object sender, System.EventArgs e)
        {
            scanPage = new ZXingScannerPage();
            sd = new SendData();
            await Navigation.PushAsync(scanPage);
            scanPage.OnScanResult += (result) =>
            {
                scanPage.IsScanning = false;
                Device.BeginInvokeOnMainThread(async () =>
                {
                    sd.Action = "personentry";
                    sd.DataToSend = result.Text;
                    await sd.SendAsync();
                    await Navigation.PopAsync();
                    await DisplayAlert("Autenticado", result.Text, "OK");
                });
            };
        }
