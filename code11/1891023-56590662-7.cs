    protected override void OnAppearing()
        {
            base.OnAppearing();
           MessagingCenter.Subscribe<ListPage, string>(this, "Invoke", async (sender, arg) =>
            {
                Debug.Write("123456---->  get one msg");
                DisplayAlert("Alert", "We have received a message.", "OK");
            });
        }
        protected async override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Unsubscribe<ListPage,string>(this, "Invoke");
        }
    }
   
