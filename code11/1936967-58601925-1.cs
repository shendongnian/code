    <ContentPage.Content>
        <StackLayout>
            <Label x:Name="label1" />
            <Button
                x:Name="btn1"
                Clicked="Btn1_Clicked"
                Text="change value" />
        </StackLayout>
    </ContentPage.Content>
    public partial class Page15 : ContentPage
    {
        public Objets model { get; set; }
        public Page15()
        {
            InitializeComponent();
            model= new Objets("test 1", 1.001f, " test11111", 12);
            this.BindingContext = model;
            label1.SetBinding(Label.TextProperty, "nbr_objet");
        }
        private void Btn1_Clicked(object sender, EventArgs e)
        {
            model.nbr_objet = 20;
        }
    }
    public class Objets : INotifyPropertyChanged
    {
        public string Designation { get; set; }
        public float Prix { get; set; }
        public string imageUrl { get; set; }
        private int Nbr_Objet;
        public int nbr_objet
        {
            get { return Nbr_Objet; }
            set
            {
                Nbr_Objet = value;
                RaisePropertyChanged("nbr_objet");
            }
        }
       
        public Objets(string Designation, float Prix, string imageUrl, int Nbr_Objet)
        {
            this.Designation = Designation;
            this.Prix = Prix;
            this.imageUrl = imageUrl;
            this.Nbr_Objet = Nbr_Objet;
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
       
        public void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
