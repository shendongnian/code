<?xml version="1.0" encoding="UTF-8"?>
<ContentView xmlns="http://xamarin.com/schemas/2014/forms" 
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:d="http://xamarin.com/schemas/2014/forms/design"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
             mc:Ignorable="d"
             x:Class="xxx.PickerView">
  <ContentView.Content>
        <Grid HeightRequest="40">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="0.9*" />
                <ColumnDefinition Width="0.1*" />
            </Grid.ColumnDefinitions>
            <Picker Grid.Column="0" x:Name="picker" Title="Select Groups" TitleColor="Red"  />
            <Label Grid.Column="1" Text="Canel" TextColor="Red">
                <Label.GestureRecognizers>
                    <TapGestureRecognizer Tapped="TapGestureRecognizer_Tapped" NumberOfTapsRequired="1" />
                </Label.GestureRecognizers>
            </Label>
        </Grid>
    </ContentView.Content>
</ContentView>
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
namespace xxx
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PickerView : ContentView
    {
        public ObservableCollection<string> pickerSource { get; set; }
        //public PickerView()
        //{
        //    InitializeComponent();
        //}
        public PickerView(ObservableCollection<string> source)
        {
            InitializeComponent();
            picker.ItemsSource = source;
        }
        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            var stack = this.Parent as StackLayout;
            stack.Children.Remove(this);
        }
    }
}
###in content page
    <StackLayout VerticalOptions="CenterAndExpand" HorizontalOptions="CenterAndExpand">
        <StackLayout x:Name="pickerStack" VerticalOptions="CenterAndExpand" HorizontalOptions="CenterAndExpand">
            
            
            
        </StackLayout>
        <Button Text="+ add another group" Clicked="Button_Clicked" />
    </StackLayout>
private void Button_Clicked(object sender, EventArgs e)
{
   var source = new ObservableCollection<string>() {"111","222","333" };
   pickerStack.Children.Add(new PickerView(source));
}
[![enter image description here][1]][1]
  [1]: https://i.stack.imgur.com/oQQmn.gif
