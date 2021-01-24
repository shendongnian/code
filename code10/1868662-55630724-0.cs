    public BoloToolbar(): base()
        {
          
        }
    protected override void OnAppearing()
        {
            base.OnAppearing();
            Init();
        }
        private void Init()
        {
            ClientViewModel Client = new ClientViewModel();
            if (Client.IsLogged == "true")
            {          
                this.ToolbarItems.Add(new ToolbarItem ("Twój Koszyk", "Images/cart.png", ()  =>
                {
                    Navigation.PushAsync(new CartPage());
                }));
                this.ToolbarItems.Add(new ToolbarItem("Moje Zamówienia", null, () =>
                {
                    Navigation.PushAsync(new Zamowienia());
                }, ToolbarItemOrder.Secondary, priority:0));
                this.ToolbarItems.Add(new ToolbarItem("Mój Profil", null, () =>
                {
                    Navigation.PushAsync(new Profile());
                }, ToolbarItemOrder.Secondary, priority: 0));
                this.ToolbarItems.Add(new ToolbarItem("Ustawienia", null, () =>
                {
                }, ToolbarItemOrder.Secondary, priority: 0));
                this.ToolbarItems.Add(new ToolbarItem("Kontakt", null, () =>
                {
                    Navigation.PushAsync(new Kontakt());
                }, ToolbarItemOrder.Secondary, priority: 0));
                this.ToolbarItems.Add(new ToolbarItem("Wyloguj", null, () =>
                {
                    //Navigation.PushAsync(new Kontakt());
                    Application.Current.Properties["isLogged"] = "false";
                    Application.Current.Properties["userId"] = "";
                    DisplayAlert("Logout", "Wylogowano Pomyślnie", "OK");
                }, ToolbarItemOrder.Secondary, priority: 0));
            } else
            {
                this.ToolbarItems.Add(new ToolbarItem("Zaloguj", null, () =>
                {
                    Navigation.PushAsync(new LogRegister());
                }, ToolbarItemOrder.Secondary, priority: 0));
                this.ToolbarItems.Add(new ToolbarItem("Utwórz Konto", null, () =>
                {
                    Navigation.PushAsync(new RegisterAccount());
                }, ToolbarItemOrder.Secondary, priority: 0));
            }
