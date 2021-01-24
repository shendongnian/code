xml
<?xml version="1.0" encoding="utf-8"?>
<ContentPage
    x:Name="myPage"
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    xmlns:d="http://xamarin.com/schemas/2014/forms/design"
    xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
    mc:Ignorable="d"
    x:Class="Playground.MainPage">
    <ListView
        ItemsSource="{Binding ListaProfissionais, Source={x:Reference myPage}}"
        x:Name="ListViewProfissionais" HorizontalOptions="FillAndExpand"
        HasUnevenRows="True"
        VerticalOptions="FillAndExpand"
        VerticalScrollBarVisibility="Never"
        HorizontalScrollBarVisibility="Never"
        BackgroundColor="Transparent"
        SeparatorColor="Transparent">
      <ListView.ItemTemplate>
        <DataTemplate>
          <ViewCell>
            <Frame HasShadow="True" CornerRadius="5" HeightRequest="215" Margin="8" Padding="4" BackgroundColor="White">
              <Grid>
                <Grid.ColumnDefinitions>
                  <ColumnDefinition Width="*"></ColumnDefinition>
                </Grid.ColumnDefinitions>
                <Grid.RowDefinitions>
                  <RowDefinition Height="15"></RowDefinition>
                  <RowDefinition Height="25"></RowDefinition>
                  <RowDefinition Height="105"></RowDefinition>
                  <RowDefinition Height="25"></RowDefinition>
                  <RowDefinition Height="25"></RowDefinition>
                </Grid.RowDefinitions>
                <Label Text="{Binding Categoria}" TextColor="#8e8e8e" FontSize="10" Grid.Column="0" Grid.Row="0" VerticalOptions="StartAndExpand" HorizontalOptions="StartAndExpand" Margin="2,0,0,0"></Label>
                <Label Text="{Binding Titulo}" FontAttributes="Bold" TextColor="#337760" FontSize="14" Grid.Column="0" Grid.Row="1" VerticalOptions="StartAndExpand" HorizontalOptions="StartAndExpand" Margin="2,0,0,0"></Label>
                <Frame Grid.Column="0" Grid.Row="2" BackgroundColor="Transparent" CornerRadius="4" Padding="0" Margin="0">
                    <Image Source="{Binding FotoPerfil}" HorizontalOptions="FillAndExpand" Aspect="AspectFill" VerticalOptions="FillAndExpand" />
                </Frame>
                <Label Text="{Binding Endereco}" TextColor="#8e8e8e" FontSize="10" Grid.Column="0" Grid.Row="3" VerticalOptions="EndAndExpand" HorizontalOptions="StartAndExpand"></Label>
                <Label Text="&#xf3c5;" Grid.Column="0" Grid.Row="4" FontSize="10" HorizontalOptions="StartAndExpand" TextColor="#ff9000" Padding="0,6,0,0">
                  <Label.FontFamily>
                    <OnPlatform x:TypeArguments="x:String" Android="Font-Awesome-Free-Solid.otf#FontAwesome5Free-Solid" iOS="FontAwesome5Free-Solid" />
                  </Label.FontFamily>
                </Label>
                <Label Text="{Binding Distancia}" TextColor="#ff9000" FontSize="10" Grid.Column="0" Grid.Row="4" VerticalOptions="Center" HorizontalOptions="StartAndExpand" Margin="10,0,0,0"></Label>
               </Grid>
            </Frame>
          </ViewCell>
         </DataTemplate>
       </ListView.ItemTemplate>
  </ListView>
</ContentPage>
Code Behind:
csharp
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace Playground
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public class Profissionais
        {
            public string Id { get; set; }
            public string Categoria { get; set; }
            public string Titulo { get; set; }
            public string FotoPerfil { get; set; }
            public string Endereco { get; set; }
            public string Distancia { get; set; }
            public string Sexo { get; set; }
        }
        private ObservableCollection<Profissionais> _listaProfissionais;
        public ObservableCollection<Profissionais> ListaProfissionais
        {
            get => _listaProfissionais;
            set
            {
                _listaProfissionais = value;
                OnPropertyChanged(nameof(ListaProfissionais));
            }
        }
        public MainPage()
        {
            InitializeComponent();
            ListaProfissionais = new ObservableCollection<Profissionais>();
        }
        private async Task Call()
        {
            // Simulating a call to the "API" and add a new element each 2 seconds
            for (int i = 0; i < 10; i++)
            {
                ListaProfissionais.Add(new Profissionais { Titulo = $"Professional {i}" });
                await Task.Delay(2000);
            }
            
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            // Call the "API" when everything is ready
            Task.Factory.StartNew(Call);
        }
    }
}
Here, as You can see, the Class Professionais does not required to inherit from INotifyPropertyChanged. The only property You need to Notify to the Binding engine is your collection. ContentPage already has a OnPropertyChanged method that you can use. After that, your ListView will listen not only a change from the property but the collection itself each time you add a new element.
Hope it helps!
**OLD**
Assuming that you are trying to bind the property `ListaProfissionais` from the code behind:
**Approcach 1 (Not a good practice):**
You must add `ListaProfissionais` to the `BindingContext` property of the class. You can approach this as follows:
csharp
... assuming you already called your API ...
ListaProfissionais = JsonConvert.DeserializeObject<ObservableCollection<Profissionais>>(resultado);
BindingContext = ListaProfissionais;
On your XAML instead of `ItemsSource="{Binding ListaProfissionais}"` use `ItemSource="{Binding BindingContext}"`
**Approach 2 (A better approach):**
Set a name in your XAML page for the class (Name="listPage"). In your ListView you can do something like this:
ItemsSource="{Binding ListaProfissionais, Source='{x:Reference listPage}'}"
Note: I'll test this later.
2. Add INotifyPropertyChanged interface to your cs file and implement its method.
Change ListaProfissionais to a property like this:
csharp
private ObservableCollection<Profissionais> _listaProfissionais;
public ObservableCollection<Profissionais> ListaProfissionais
{
    get => _listaProfissionais;
    set 
    {
        _listaProfissionais = value;
        // This should be the method implemented by INotifyPropertyChanged.
        OnPropertyChanged(nameof(ListaProfissionais);
    }
}
Notes:
The list will not notify the ListView if you don't Notify the Binding engine that the property changed. With this, We are making sure that the binding context of the ListView is listening to the property changes from ListProfessionais.
Hope it helps.
