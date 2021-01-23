    <ComboBox ItemsSource="{Binding Source={x:Static local:MainWindow.MicModeOptions} , Mode=OneWay}"/>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
    
        public **static** CfgData.TMicMode[] MicModeOptions
        {
        }
    }
    
