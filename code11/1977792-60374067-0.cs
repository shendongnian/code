    Device.BeginInvokeOnMainThread(YourAsyncMethod);
    private async void YourAsyncMethod()
    {
        //...
        VidljivoDugmePretrazi = true;
        try
        {
          await GetDataAsync();
        }
        catch (Exception e) 
        {
          //...
        }
        finally
        {
           VidljivoDugmePretrazi = false;
        }
    }
