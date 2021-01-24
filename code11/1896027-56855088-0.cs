      [XamlCompilation(XamlCompilationOptions.Compile)]
            public partial class ConvidarAmigosEmail : ContentView
            {
                public ConvidarAmigosEmailViewModel ViewModel { get; set; }
                public ConvidarAmigosEmail ()
                {
                    ViewModel = new ConvidarAmigosEmailViewModel();
                    InitializeComponent ();
                    BindingContext = new ConvidarAmigosEmailViewModel();
                }
        
                public async override OnAppearing()
                {
                    // will be good that you show loading icon while processing data
                    await ViewModel.LoadData();
                }
                private void ListaEmail_ItemSelected(object sender, SelectedItemChangedEventArgs e)
                {
                    if (e.SelectedItem == null) return;
                    listaEmail.SelectedItem = null;
                }
        
                private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
                {
        
                }
            }
        
        
