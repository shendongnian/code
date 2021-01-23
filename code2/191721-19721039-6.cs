    public class Type3VM : INotifyPropertyChanged
        {
            private List<MenuData> menuData = new List<MenuData>(new[] 
            {
                new MenuData("Zero", 0),
                new MenuData("One", 1),
                new MenuData("Two", 2),
                new MenuData("Three", 3),
            });
    
            public IEnumerable<MenuData> MenuData { get { return menuData.ToList(); } }
         
            private int selected;
            public int Selected
            {
                get { return selected; }
                set { selected = value; OnPropertyChanged(); }
            }
    
            private ICommand contextMenuClickedCommand;
            public ICommand ContextMenuClickedCommand { get { return contextMenuClickedCommand; } }
    
            private void ContextMenuClickedAction(object clicked)
            {
                var data = clicked as MenuData;
                Selected = data.Item2;
                OnPropertyChanged("MenuData");
            }
    
            public Type3VM()
            {
                contextMenuClickedCommand = new RelayCommand(ContextMenuClickedAction);
            }
    
            private void OnPropertyChanged([CallerMemberName]string propertyName = null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
    
            public event PropertyChangedEventHandler PropertyChanged;
        }
    
        public class MenuData : Tuple<String, int>
        {
            public MenuData(String DisplayValue, int value) : base(DisplayValue, value) { }
        }
    <UserControl x:Class="SampleApp.Views.Type3"
                 xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
                 xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
                 xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
                 xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
                 xmlns:Views="clr-namespace:SampleApp.Views"
                 xmlns:Converters="clr-namespace:SampleApp.Converters"
                 xmlns:ViewModels="clr-namespace:SampleApp.ViewModels"
                 mc:Ignorable="d" 
                 d:DesignHeight="300" d:DesignWidth="300"
                 d:DataContext="{d:DesignInstance ViewModels:Type3VM}"
                 >
        <UserControl.Resources>
            <Converters:AllValuesEqualToBooleanConverter x:Key="IsCheckedVisibilityConverter" EqualValue="True" NotEqualValue="False" />
        </UserControl.Resources>
        <Grid>
            <Grid.ContextMenu>
                <ContextMenu ItemsSource="{Binding MenuData, Mode=OneWay}">
                    <ContextMenu.ItemContainerStyle>
                        <Style TargetType="MenuItem" >
                            <Setter Property="Header" Value="{Binding Item1}" />
                            <Setter Property="IsCheckable" Value="True" />
                            <Setter Property="IsChecked">
                                <Setter.Value>
                                    <MultiBinding Converter="{StaticResource IsCheckedVisibilityConverter}" Mode="OneWay">
                                        <Binding Path="DataContext.Selected" RelativeSource="{RelativeSource FindAncestor, AncestorType={x:Type Views:Type3}}"  />
                                        <Binding Path="Item2" />
                                    </MultiBinding>
                                </Setter.Value>
                            </Setter>
                            <Setter Property="Command" Value="{Binding Path=DataContext.ContextMenuClickedCommand, RelativeSource={RelativeSource FindAncestor, AncestorType={x:Type Views:Type3}}}" />
                            <Setter Property="CommandParameter" Value="{Binding .}" />
                        </Style>
                    </ContextMenu.ItemContainerStyle>
                </ContextMenu>
            </Grid.ContextMenu>
            <Grid.RowDefinitions><RowDefinition Height="*" /></Grid.RowDefinitions>
            <Grid.ColumnDefinitions><ColumnDefinition Width="*" /></Grid.ColumnDefinitions>
            <TextBlock Grid.Row="0" Grid.Column="0" FontSize="30" Text="Right Click For Menu" />
        </Grid>
    </UserControl>
    public class AreAllValuesEqualConverter<T> : IMultiValueConverter
    {
        public T EqualValue { get; set; }
        public T NotEqualValue { get; set; }
        public object Convert(object[] values, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            T returnValue;
            if (values.Length < 2)
            {
                returnValue = EqualValue;
            }
            // Need to use .Equals() instead of == so that string comparison works, but must check for null first.
            else if (values[0] == null)
            {
                returnValue = (values.All(v => v == null)) ? EqualValue : NotEqualValue;
            }
            else
            {
                returnValue = (values.All(v => values[0].Equals(v))) ? EqualValue : NotEqualValue;
            }
            return returnValue;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
    [ValueConversion(typeof(object), typeof(Boolean))]
    public class AllValuesEqualToBooleanConverter : AreAllValuesEqualConverter<Boolean>
    { }
