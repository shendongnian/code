    <Window x:Class="WpfApplication3.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:WpfApplication3="clr-namespace:WpfApplication3" Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <WpfApplication3:MainView x:Key="MainView"/>
            <DataTemplate x:Key="HasViewItemTemplate">
                <ContentPresenter Content="{Binding Path=MyView}"/>
            </DataTemplate>
        </Window.Resources>
        <Grid>
            <ItemsControl Background="Yellow" ItemTemplate="{StaticResource HasViewItemTemplate}" ItemsSource="{Binding Source={StaticResource MainView}, Path=MyViews}">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <VirtualizingStackPanel Orientation="Vertical"/>
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
            </ItemsControl>
        </Grid>
    </Window>
    
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Data;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    using System.Windows.Navigation;
    using System.Windows.Shapes;
    using System.Collections;
    using System.ComponentModel;
    using System.Collections.ObjectModel;
    
    namespace WpfApplication3
    {
        public interface IHasView
        {
            UserControl MyView { get; }
        }
    
        public class Car : IHasView
        {
            public UserControl MyView
            { 
                get
                {
                    // Demo UserControl as prodcued by MyCarViewThatHasAButton
    
                    UserControl ctl = new UserControl();
    
                    ctl.Background = Brushes.Red;
    
                    Button button = new Button();
    
                    button.Content = "a car";
    
                    ctl.Content = button;
    
                    return ctl;
                }
            }
        }
    
        public class Jeep : IHasView
        {
            public UserControl MyView
            {
                get
                {
                    // Demo UserControl as produced by MyJeepViewThatHasATextblock
    
                    UserControl ctl = new UserControl();
    
                    ctl.Background = Brushes.Blue;
                    ctl.Width = 50;
    
                    TextBlock textblock = new TextBlock();
    
                    textblock.Text = "a jeep";
    
                    ctl.Content = textblock;
    
                    return ctl;
                }
            }
        }
    
        public class MainView : INotifyPropertyChanged{
    
            public MainView()
            {
                ObservableCollection<IHasView> list = new ObservableCollection<IHasView>()
                                                          {
                                                              new Car(),
                                                              new Jeep()
                                                          };
    
                MyViews = list;
            }
    
            private ICollection _myViews;
            public ICollection MyViews
            {
                get
                {
                    return _myViews;
                }
                set
                { 
                   _myViews = value; 
                   NotifyPropertyChanged("MyViews");
                }
            }
    
            private void NotifyPropertyChanged(string p)
            {
                if (PropertyChanged != null)
                {
                    PropertyChangedEventArgs e = new PropertyChangedEventArgs(p);
    
                    PropertyChanged(this, e);
                }
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
        }
    }
