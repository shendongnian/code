    public async Task DoThings() {
    
      if (somethingMissing()){
        Device.BeginInvokeOnMainThread(async () =>
          await App.Current.MainPage.DisplayAlert("Error", "Fix errors", "Ok"));
      }
      else
      {
        DoStuff();
      }
    }
