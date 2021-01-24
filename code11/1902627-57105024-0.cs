    public partial class MenuPage : ContentPage
    {
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        // private readonly MenuItemsViewModel _viewModel;
         
        public MenuPage(MenuItemsViewModel viewModel)
        {
            BindingContext = viewModel; // <---------- changed line
            ...
        }
    }
