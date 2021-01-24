        public override async Task OnAppearing()
        {
            await base.OnAppearing();
            try
            {
                IsBusy = true;
                await FetchActivityDetail(); 
                await FetchCategories(); 
            }
            catch (Exception ex)
            {
                //handle/display error
            }
            finally 
            {
                IsBusy = false;
            }
        }
