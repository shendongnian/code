c#
public class WeaponViewModel : ViewModelBase
{
    private readonly string _name;
    private string abbreviation;
    private int damage;
    private bool isShown;
    public WeaponViewModel(string name, string abbreviation, int damage, bool isShown)
    {
        _name = name;
        this.Abbreviation = abbreviation;
        this.Damage = damage;
        this.IsShown = isShown;
    }
    public string Name => _name;
    public string Abbreviation
    {
        get { return abbreviation; }
        set
        {
            abbreviation = value;
            OnPropertyChanged();
        }
    }
    public int Damage
    {
        get { return damage; }
        set
        {
            damage = value;
            OnPropertyChanged();
        }
    }
    public bool IsShown
    {
        get { return isShown; }
        set
        {
            isShown = value;
            OnPropertyChanged();
        }
    }
}
**MainViewModel.cs**
c#
public class MainViewModel : ViewModelBase
{
    public MainViewModel()
    {
        Weapons = new ObservableCollection<WeaponViewModel>(GetWeapons());
        DropDownWeapons = (CollectionView)new CollectionViewSource { Source = Weapons }.View;
        DropDownWeapons.Filter = DropDownFilter;
    }
    #region DataGrid
    public ObservableCollection<WeaponViewModel> Weapons { get; }
    private WeaponViewModel currentWeapon;
    public WeaponViewModel CurrentWeapon
    {
        get { return currentWeapon; }
        set
        {
            currentWeapon = value;
            OnPropertyChanged();
        }
    }
    #endregion DataGrid
    #region ComboBox
    public CollectionView DropDownWeapons { get; } 
    private WeaponViewModel selectedWeapon;
    public WeaponViewModel SelectedWeapon
    {
        get { return selectedWeapon; }
        set
        {
            if (value != null)
            {
                selectedWeapon = value;
                ReplaceCurrentWith(selectedWeapon);
                OnPropertyChanged();
            }
        }
    }
    private void ReplaceCurrentWith(WeaponViewModel requestedWeapon)
    {
        currentWeapon.IsShown = false;
        requestedWeapon.IsShown = true;
        var currentWeaponIndex = Weapons.IndexOf(currentWeapon);
        var requestedWeaponIndex = Weapons.IndexOf(requestedWeapon);
        Weapons.Move(requestedWeaponIndex, currentWeaponIndex);
        DropDownWeapons.Refresh();
    }
    private bool DropDownFilter(object item)
    {
        var weapon = (WeaponViewModel)item;
        return weapon.IsShown == false;
    }
    #endregion ComboBox
    private static IList<WeaponViewModel> GetWeapons()
    {
        var weapons = new List<WeaponViewModel>
        {
            new WeaponViewModel("Assault Rifle", "AR", 30, true),
            new WeaponViewModel("Submachine Gun", "SM", 17, true),
            new WeaponViewModel("Revolver", "RV", 54, true),
            new WeaponViewModel("Shotgun", "AR", 30, true),
            new WeaponViewModel("Sniper", "SN", 63, true),
            new WeaponViewModel("Rocket Launcher", "RL", 300, true),
            new WeaponViewModel("Grenade Launcher", "GL", 200, true),
            new WeaponViewModel("Minigun", "MG", 20, true),
            new WeaponViewModel("Knife", "KN", 10, false),
            new WeaponViewModel("Baseball Bat", "BB", 6, false),
        };
        return weapons;
    }
}
**MainWindow.xaml**
xaml
<Window x:Class="WpfApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:vm="clr-namespace:WpfApp.ViewModels"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800" WindowStartupLocation="CenterScreen">
    <Window.DataContext>
        <vm:MainViewModel/>
    </Window.DataContext>
    <DataGrid ItemsSource="{Binding Weapons}" SelectedItem="{Binding CurrentWeapon}"
              AutoGenerateColumns="False">
        <DataGrid.RowStyle>
            <Style TargetType="{x:Type DataGridRow}">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsShown}" Value="False">
                        <Setter Property="Visibility" Value="Collapsed"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.RowStyle>
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="Weapons">
                <DataGridTemplateColumn.CellEditingTemplate>
                    <DataTemplate>
                        <ComboBox DataContext="{Binding DataContext, RelativeSource={RelativeSource AncestorType={x:Type Window}}}"
                            ItemsSource="{Binding DropDownWeapons}"
                            SelectedItem="{Binding SelectedWeapon}"
                            DisplayMemberPath="Name"
                            IsEditable="False" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellEditingTemplate>
                <DataGridTemplateColumn.CellTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Name}" />
                    </DataTemplate>
                </DataGridTemplateColumn.CellTemplate>
            </DataGridTemplateColumn>
            <DataGridTextColumn Header="Name" Binding="{Binding Name}" IsReadOnly="True" />
            <DataGridTextColumn Header="AB" Binding="{Binding Abbreviation}" />
            <DataGridTextColumn Header="Damage"  Binding="{Binding Damage}" />
        </DataGrid.Columns>
    </DataGrid>
</Window>
