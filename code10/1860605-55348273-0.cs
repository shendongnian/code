    <Window x:Class="WindowTitle.MainWindow"
                xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
                xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
                xmlns:local="clr-namespace:WindowTitle"
                mc:Ignorable="d"
                MinWidth="400"
                SizeToContent="WidthAndHeight"
                Title="{Binding MainWindowTitle}">
        <Grid Margin="5">
            <Button Click="Button_Click"
                        Content="Change by Binding"
                        HorizontalAlignment="Left"
                        Padding="5,0"/>
            <Button x:Name="ChangeBtn"
                        Click="ChangeBtn_Click"
                        Content="Change by Name"
                        HorizontalAlignment="Right"
                        Padding="5,0"/>
        </Grid>
    </Window>
    using System.Windows;
    namespace WindowTitle {
        public partial class MainWindow : Window, System.ComponentModel.INotifyPropertyChanged {
            public void Button_Click(object sender, RoutedEventArgs e) {
                MainWindowTitle = titleCount.ToString();
                ++titleCount;
            }
            void ChangeBtn_Click(object sender, RoutedEventArgs e) {
                --titleCount;
                Title = titleCount.ToString();
            }
            public MainWindow() { InitializeComponent(); DataContext = this; }
            public string MainWindowTitle {
                get { return mainWindowTitleBase; }
                set {
                    value = value.Trim();
                    if (value != mainWindowTitleBase) {
                        mainWindowTitleBase = value;
                        OnPropertyChanged("MainWindowTitle");
                    }
                }
            }
            string mainWindowTitleBase = "Default Title";
            public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;
            int titleCount = 0;
            protected void OnPropertyChanged(string /*property name*/ ptyNam) {
                PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(ptyNam));
            }
        }
    }
