    public RecetaView()
        {
            InitializeComponent();
            this.BindingContext = this;
            listadoRecetas.ItemsSource = recetasList;
  
        }
        protected async override void OnAppearing()
         {
             getRecipes();
             base.OnAppearing();
         }
