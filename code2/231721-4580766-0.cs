    <Window x:Class="ListviewItemLoadedSpike.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <Storyboard x:Key="FadeIn">
                <DoubleAnimation 
                    Storyboard.TargetProperty="Opacity" 
                    Duration="0:0:2" From="0" To="1"/>
            </Storyboard>
            <Style TargetType="Label" x:Key="FadingLabel">
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Loaded">
                        <BeginStoryboard Storyboard="{StaticResource FadeIn}"/>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </Window.Resources>
        <StackPanel>
            <ListBox ItemsSource="{Binding Data}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <Label Content="{Binding Info}"
                               Style="{StaticResource FadingLabel}"/>
                    </DataTemplate>
                </ListBox.ItemTemplate>
                
            </ListBox>
            <Button Name="AddButton"
                    Click="AddButton_Click">
                Add Item
            </Button>
        </StackPanel>
    </Window>
    using System.Collections.ObjectModel;
    using System.Windows;
    
    namespace ListviewItemLoadedSpike
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private int counter;
            public MainWindow()
            {
                InitializeComponent();
                Data=new ObservableCollection<Datum>();
                DataContext = this;
            }
    
            private void AddButton_Click(object sender, RoutedEventArgs e)
            {
                counter++;
                Data.Add(new Datum(counter.ToString()));
            }
    
            public ObservableCollection<Datum> Data { get; set; }
        }
    
        public class Datum
        {
            public Datum(string info)
            {
                Info = info;
            }
    
            public string Info { get; set; }
        }
    }
