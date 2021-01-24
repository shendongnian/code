    
    <Window x:Class="WpfApp1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
            xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
            mc:Ignorable="d"
            Title="MainWindow" Height="400" Width="800">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="*"/>
                <ColumnDefinition Width="*"/>
            </Grid.ColumnDefinitions>
            <Grid.RowDefinitions>
                <RowDefinition Height="300*"/>
                <RowDefinition Height="50"/>
            </Grid.RowDefinitions>
            <DataGrid Grid.Column="0" Grid.Row="0" Width="Auto" ItemsSource="{Binding DeviceList}" SelectedItem="{Binding SelectedDevice}" AutoGenerateColumns="True" />
            <DataGrid Grid.Column="1" Grid.Row="0" Width="Auto" DataContext="{Binding SelectedDevice}" ItemsSource="{Binding Path=FaultList}" AutoGenerateColumns="True"/>
            <Button Content="Trigger DataGrid 1 update" Grid.Column="0" Grid.Row="1" Margin="10,10,10,10" Width="Auto" Height="Auto" Click="Button_Click"/>
        </Grid>
    </Window>
    // Code behind in MainWindow.xaml.cs
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Windows;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            private MainViewModel vm;
            public MainWindow()
            {
                InitializeComponent();
                vm = new MainViewModel();
                DataContext = vm;
            }
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                vm.AddDevice();
            }
        }
    }
