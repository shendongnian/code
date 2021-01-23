    public partial class MainWindow : Window
    {
        public void ShowCampers()
        {
            var campersPage = new CampersPage((BindingCampers) this.DataContext);
            // show campersPage
        }
    }
