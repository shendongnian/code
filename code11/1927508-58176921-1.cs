    public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
                Classes = new LesClasses();
                Classe maClasse = new Classe("Test");
                Classes.Add(maClasse);
                DataContext = this;
            }
    
            public LesClasses Classes { get; set; }
    
            private void cd_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
            {
                Classe classe = new Classe("test2");
                Classes.Add(classe);
            }
        }
