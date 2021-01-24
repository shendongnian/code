    protected override void OnAppearing()
        {
            base.OnAppearing();
            MessagingCenter.Subscribe<object, object>(this, "Invoke", (sender, arg) =>
            {
                //await Process(arg);
            });
        }
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<object, object>(this, "Invoke");
            await Navigation.PopAsync();
        }
    }
   
