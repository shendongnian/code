<Window x:Class="WpfApp3.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp3"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800" KeyDown="MainWindow_OnKeyDown">
    <Canvas>
        <Button Name="MyButton" Canvas.Right="10">Test</Button>
    </Canvas>
</Window>
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        private void MainWindow_OnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                //Whatever, just an example
                Canvas.SetRight(MyButton, Canvas.GetRight(MyButton) + 5);
            }
        }
    }
}
