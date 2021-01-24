    catch (MsalUiRequiredException ex)
    {
        try
        {
             authResult = await App.PCA.AcquireTokenInteractive(App.Scopes)
                                          .WithParentActivityOrWindow(App.ParentWindow)
                                          .WithUseEmbeddedWebView(true)
                                          .ExecuteAsync();
         }
         catch (Exception ex2)
         {
             await DisplayAlert("Acquire token interactive failed. See exception message for details: ", ex2.Message, "Dismiss");
         }
    }
