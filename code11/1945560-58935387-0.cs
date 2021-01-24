        <StackPanel HorizontalAlignment="Left" VerticalAlignment="Center" Orientation="Horizontal" Grid.Column="0" Margin="20,0,0,0">
            <RadioButton x:Name="XMLViewButton" GroupName="DisplayType" IsChecked="{Binding XmlViewIsChecked, FallbackValue=True, Mode=TwoWay}" Content="XML View" Margin="0,0,5,0"/>
            <RadioButton x:Name="TextViewButton" GroupName="DisplayType" IsChecked="{Binding TextViewIsChecked, FallbackValue=False, Mode=TwoWay}" Content="Text View" Margin="5,0,0,0"/>
            <Button Content="Check" Click="Button_Click" />
        </StackPanel>
----------
    public partial class MainWindow : Window
    {
        public bool XmlViewIsChecked { get; set; }
        public bool TextViewIsChecked { get; set; }
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (TextViewIsChecked)
            {
                Clipboard.SetText("text");
            }
            else if (XmlViewIsChecked)
            {
                Clipboard.SetText("xml");
            }
        }
    }
