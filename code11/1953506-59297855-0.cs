    As per my understanding you want to display picker values when page load.
    
     protected override void OnAppearing()
      {
                base.OnAppearing();
                Device.BeginInvokeOnMainThread(() =>
                {
                    if (selection.IsFocused)
                        selection.Unfocus();
                    else
                    selection.Focus();
                });
            }
