	protected async override void OnAppearing()
	{
        base.OnAppearing();
 		Task.Run(async () =>
		{
			await Task.Delay(TimeSpan.FromSeconds(10));
			if (CrossConnectivity.Current.IsConnected)
			{
				//Some code here
			    Device.BeginInvokeOnMainThread(() =>
			    {
                     // If you need to update an UI element
			    });
			}
		});
     }
