    private async void PostcodeButton_Click(object sender, RoutedEventArgs e) {
        _clearStatus();
    
        if (_validatePostcode()) {
            // get long lat from api
            var service = new PostcodeService();
            var location = await service.GetLongLatAsync(PostcodeTextBox.Text); //Offload UI thread
            //Back on UI thread
            if(location != null) {
            
                ResultTextBlock.Text = location.Latitude.ToString();
            } else {
                //Some message here
            }
            
        }
    }
