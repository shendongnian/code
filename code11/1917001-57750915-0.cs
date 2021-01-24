xml
<UserControl x:Class="StackOverflow.CoreUI"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008" 
             xmlns:local="clr-namespace:StackOverflow"
             mc:Ignorable="d" 
             d:DesignHeight="30" d:DesignWidth="100">
    <Grid>
        <TextBox Text="{Binding Text}" />
    </Grid>
</UserControl>
*CoreUI.xaml.cs*:
csharp
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
namespace StackOverflow
{
    public class LogEventArgs : EventArgs {
        public string Message { get; set; }
    }
    public delegate void LogEventHandler(object sender, LogEventArgs e);
    public partial class CoreUI : UserControl
    {
        public string Text { get; set; } = "Hello, world!";
        public LogEventHandler OnLog;
        public CoreUI()
        {
            InitializeComponent();
            DataContext = this;
        }
        public void HookWndProc(Window window)
        {
            var source = HwndSource.FromVisual(window) as HwndSource;
            source.AddHook(new HwndSourceHook(WndProc));
        }
        protected IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            MouseButtonEventArgs args;
            const int WM_LBUTTONDOWN = 0x0201;
            const int WM_LBUTTONUP = 0x0202;
            const int WM_MOUSEMOVE = 0x0200;
            ////Not required...
            //// REF: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest
            //const int WM_NCHITTEST = 0x0084;
            //const int HTCLIENT = 0x0001;
            switch (msg)
            {
                ////Not required...
                //case WM_NCHITTEST:
                //    {
                //        handled = true;
                //        return new IntPtr(HTCLIENT);
                //    }
                case WM_LBUTTONDOWN:
                    {
                        OnLog?.Invoke(this, new LogEventArgs() { Message = "LBUTTONDOWN" });
                        handled = true;
                        break;
                    }
                case WM_LBUTTONUP:
                    {
                        OnLog?.Invoke(this, new LogEventArgs() { Message = "LBUTTONUP" });
                        handled = true;
                        break;
                    }
                case WM_MOUSEMOVE:
                    {
                        OnLog?.Invoke(this, new LogEventArgs() { Message = "MOUSEMOVE" });
                        handled = true;
                        break;
                    }
            }
            return IntPtr.Zero;
        }
    }
}
*MainWindow.xaml*:
xml
<Window x:Class="StackOverflow.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:StackOverflow"
        mc:Ignorable="d"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <local:CoreUI x:Name="coreUI" Height="30" VerticalAlignment="Top"/>
        <TextBox x:Name="textBox" Margin="0,30,0,0" TextWrapping="Wrap" Text="TextBox"/>
    </Grid>
</Window>
*MainWindow.xaml.cs*:
csharp
using System;
using System.Windows;
namespace StackOverflow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            textBox.Clear();
            coreUI.OnLog += new LogEventHandler(OnLogHandler);
        }
        protected void OnLogHandler(object sender, LogEventArgs e)
        {
            textBox.AppendText(e.Message + "\r\n");
        }
        protected override void OnSourceInitialized(EventArgs e)
        {
            base.OnSourceInitialized(e);
            coreUI.HookWndProc(App.Current.MainWindow);
        }
    }
}
Note the use of `OnSourceInitialized()`. The main window will not have been allocated a window handle yet if you try this from `OnInitialized()`.
The UserControl (CoreUI) receives `WM_LBUTTONDOWN`, `WM_LBUTTONUP` and `WM_MOUSEMOVE` events for the entire application window. If your UserControl does not fill the entire application window then it will be your control's responsibility to filter these events down to itself by checking the mouse coordinates against its own bounds.
