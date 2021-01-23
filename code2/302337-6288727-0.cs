    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            xmlns:local="clr-namespace:WpfApplication1"
            Title="MainWindow" Height="350" Width="525">
        <local:Class1 CheckFormat="{x:Static local:FCS.FormatDigitsOnly}" />
    </Window>
    namespace WpfApplication1
    {
        public delegate bool CheckFormatDelegate(int row, int col, ref string text);
        public class Class1
        {
            public virtual CheckFormatDelegate CheckFormat { get; set; }
        }
        public class FCS
        {
            private static bool FormatDigitsOnlyImpl(int row, int col, ref string text)
            {
                return true;
            }
    
            public static CheckFormatDelegate FormatDigitsOnly
            {
                get { return FormatDigitsOnlyImpl; }
            }
        }
    }
