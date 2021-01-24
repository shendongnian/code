    public partial class MainWindow : Window
    {
        List<EqualisationSetting> equalisationSettings;
        
        public MainWindow()
        {
            InitializeComponent();
            equalisationSettings = new List<EqualisationSetting>
            {
                new EqualisationSetting { LowerFrequencyBound = 20, UpperFrequencyBound = 250, DecibelRatioChange = 0 },
                new EqualisationSetting { LowerFrequencyBound = 250, UpperFrequencyBound = 4000, DecibelRatioChange = 0}
            };
            ItemsCountroller.ItemsSource = equalisationSettings;
        }
        private void AddFrequencyBoundButton_Click(object sender, RoutedEventArgs e)
        {
            equalisationSettings.add(new EqualisationSetting();
        }
    }
