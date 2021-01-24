public class SumConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        return values.Cast<int>()?.Sum()?.ToString();
    }
    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        return null;
    }
}
And use it in XAML like this
<TextBox>
    <TextBox.Resources>
        <local:SumConverter x:Key="SumConverter"/>
    </TextBox.Resources>
    <TextBox.Text>
        <MultiBinding Converter="{StaticResource SumConverter}">
            <Binding Path="Text" ElementName="OtherTextBox1" />
            <Binding Path="Text" ElementName="OtherTextBox2" />
            <Binding Path="Text" ElementName="OtherTextBox3" />
            <Binding Path="Text" ElementName="OtherTextBox4" />
            <Binding Path="Text" ElementName="OtherTextBox5" />
        </MultiBinding>
    </TextBox.Text>
</Control>
Hope this helps
**EDIT**
I've made a test project to show you the full code for both of my suggested solutions, here it is:
**Solution one**
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
namespace StackOverflowTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new SimpleMath();
        }
    }
    public class SimpleMath : INotifyPropertyChanged
    {
        private int _numberOne;
        public int NumberOne
        {
            get => _numberOne;
            set
            {
                _numberOne = value;
                OnPropertyChanged();
                CalculateSum();
            }
        }
        private int _numberTwo;
        public int NumberTwo
        {
            get => _numberTwo;
            set
            {
                _numberTwo = value;
                OnPropertyChanged();
                CalculateSum();
            }
        }
        private int _numberThree;
        public int NumberThree
        {
            get => _numberThree;
            set
            {
                _numberThree = value;
                OnPropertyChanged();
                CalculateSum();
            }
        }
        private int _numberSum;
        public int NumberSum
        {
            get => _numberSum;
            set
            {
                _numberSum = value;
                OnPropertyChanged();
            }
        }
        private void CalculateSum()
        {
            NumberSum = NumberOne + NumberTwo + NumberThree;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName()] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
<Window x:Class="StackOverflowTest.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:StackOverflowTest"
        mc:Ignorable="d"
        Title="MainWindow" Height="200" Width="200">
    <StackPanel>
        <TextBox x:Name="TxtOne" HorizontalAlignment="Stretch" Text="{Binding NumberOne}" Margin="10,10,10,0"/>
        <TextBox x:Name="TxtTwo" HorizontalAlignment="Stretch" Text="{Binding NumberTwo}" Margin="10,10,10,0"/>
        <TextBox x:Name="TxtThree" HorizontalAlignment="Stretch" Text="{Binding NumberThree}" Margin="10,10,10,0"/>
        <TextBlock HorizontalAlignment="Center" Text="{Binding NumberSum}" Margin="10,10,10,0"/>
    </StackPanel>
</Window>
**Solution two**
using System;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Collections.Generic;
namespace StackOverflowTest
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new SimpleMath();
        }
    }
    public class SimpleMath : INotifyPropertyChanged
    {
        private int _numberOne;
        public int NumberOne
        {
            get => _numberOne;
            set
            {
                _numberOne = value;
                OnPropertyChanged();
            }
        }
        private int _numberTwo;
        public int NumberTwo
        {
            get => _numberTwo;
            set
            {
                _numberTwo = value;
                OnPropertyChanged();
            }
        }
        private int _numberThree;
        public int NumberThree
        {
            get => _numberThree;
            set
            {
                _numberThree = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName()] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class SumConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            var numbers = new List<int>();
            foreach (var item in values)
            {
                if(item is string stringValue)
                {
                    try
                    {
                        numbers.Add(System.Convert.ToInt32(stringValue));
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Oops, not a number...");
                    }
                }
            }
            return numbers.Sum().ToString();
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
<Window x:Class="StackOverflowTest.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:StackOverflowTest"
        mc:Ignorable="d"
        Title="MainWindow" Height="200" Width="200">
    <StackPanel>
        <TextBox x:Name="TxtOne" HorizontalAlignment="Stretch" Text="{Binding NumberOne}" Margin="10,10,10,0"/>
        <TextBox x:Name="TxtTwo" HorizontalAlignment="Stretch" Text="{Binding NumberTwo}" Margin="10,10,10,0"/>
        <TextBox x:Name="TxtThree" HorizontalAlignment="Stretch" Text="{Binding NumberThree}" Margin="10,10,10,0"/>
        <TextBlock HorizontalAlignment="Center" Margin="10,10,10,0">
            <TextBlock.Resources>
                <local:SumConverter x:Key="SumConverter"/>
            </TextBlock.Resources>
            <TextBlock.Text>
                <MultiBinding Converter="{StaticResource SumConverter}">
                    <Binding Path="Text" ElementName="TxtOne" />
                    <Binding Path="Text" ElementName="TxtTwo" />
                    <Binding Path="Text" ElementName="TxtThree" />
                </MultiBinding>
            </TextBlock.Text>
        </TextBlock>
    </StackPanel>
</Window>
Here's how it looks
[![example][1]][1]
  [1]: https://i.stack.imgur.com/qRiHY.png
