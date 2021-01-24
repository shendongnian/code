    async void OnTap (object sender, EventArgs e)  
        {
            await Navigation.PushAsync(new DetailPage());
            try
            {
                MessagingCenter.Send(this, "Invoke", "Invokedtrue");
               
                Debug.Write("123456---->  send one msg");
            }
            catch (Exception ex)
            {
                Debug.Write(ex);
            }
        }
