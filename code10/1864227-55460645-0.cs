c#
    public class PageA {
        private bool returnedFromModal = false;
    
        private async void ShowB_Clicked (object sender, EventArgs e) {
           returnedFromModal = false;
           await Navigation.PushModalAsync(new NavigationPage(new PageB()));
           returnedFromModal = true;
        }
    
        protected override async void OnAppearing() {
           base.OnAppearing();
           if (returnedFromModal) {
               returnedFromModal = false;
               await Navigation.PushAsync(new PageC());
           }
        }
    }
