    <UserControl
        x:Class="Application1.MainPage"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        mc:Ignorable="d"
        d:DesignHeight="768" 
        d:DesignWidth="1366">
        <Grid 
            x:Name="LayoutRoot" 
            Background="#FF0C0C0C">
            <Rectangle
                x:Name="rect"
                Fill="Black"
                Margin="40,40,0,0" />
            <ComboBox
                Margin="40,40,0,0"
                VerticalAlignment="Top"
                HorizontalAlignment="Left"
                ItemsSource="{Binding Items}">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock
                            Text="{Binding Text}" />
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
        </Grid>
    </UserControl>
    using System.Collections.Generic;
    namespace Application1
    {
        partial class MainPage
        {
            public MainPage()
            {
                InitializeComponent();
                this.DataContext = new MainViewModel();
            }
        }
        public class MyItem
        {
            public string Text { get; set; }
            public int Id { get; set; }
        }
        public class MainViewModel
        {
            public List<MyItem> Items { get; set; }
            public MainViewModel()
            {
                this.Items = new List<MyItem>();
                this.Items.Add(new MyItem { Text = "Item 1", Id = 1 });
                this.Items.Add(new MyItem { Text = "Item 2", Id = 2 });
            }
        }
    }
