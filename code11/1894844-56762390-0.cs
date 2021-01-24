           // in constructor
            ButtonTappedCommand = new Command(async () => await OnButtonTappedCommand()) ;
            page = new Rg.Plugins.Popup.Pages.PopupPage();
        }
        
        private async Task OnButtonTappedCommand()
        {
            page.Content = new Button() 
            { 
               Text="Close", 
               Command=new Command(()=>PopupNavigation.Instance.PopAsync()) 
            };
            page.Disappearing += Popup_Disappearing;
            await PopupNavigation.Instance.PushAsync(page);
        }
        private void Popup_Disappearing(object sender, EventArgs e)
        {
            page.Disappearing -= Popup_Disappearing;
            Debug.WriteLine("Someone closed the popup");
        }
