    public partial class vorhandeneNachbestellungen : Window
    {
        public vorhandeneNachbestellungen(string hv)
        {
            InitializeComponent();
            this.DataContext = new vorhandeneNachbestellungenViewModel(hv);                      
        }
