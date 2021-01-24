       var btn=new Button();
            btn.CommandParameter = new MasterDetailPage1();
            btn.Command = new Command<MasterDetailPage1>((key) =>
             {
                // Navigation.PushAsync(key);
                 Navigation.PushModalAsync(key);
             });
