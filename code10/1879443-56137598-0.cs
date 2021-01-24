    public class MyView : ContenPage {
        private bool isDataLoaded = false;
        public void MyView {
            BindingContext = new MyViewModel();
        }
        protected async override void OnAppearing(){
            if (!isDataLoaded && BindingContext is MyViewModel vm){
                await vm.LoadDataAsync();
                isDataLoaded = true;
            }
        }
    }
