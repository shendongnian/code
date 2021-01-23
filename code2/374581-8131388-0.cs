    <Window
        x:Class="Wpf_Playground.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow"
        Height="350"
        Width="525">
        <Grid>
            <RichTextBox
                Margin="0,0,0,32"
                x:Name="rtb"
                SpellCheck.IsEnabled="True"
                SelectionChanged="RtbSelectionChanged"
                TextChanged="RtbTextChanged">
            </RichTextBox>
            <Rectangle
                x:Name="rect"
                Width="30"
                Height="30"
                Fill="#80000000"
                VerticalAlignment="Top"
                HorizontalAlignment="Left"
                IsHitTestVisible="False"/>
            <TextBlock
                x:Name="tb"
                Margin="0"
                VerticalAlignment="Bottom" />
        </Grid>
    </Window>
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    namespace Wpf_Playground
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MainWindow"/> class.
            /// </summary>
            public MainWindow()
            {
                InitializeComponent();
            }
            private void RtbSelectionChanged(object sender, RoutedEventArgs e)
            {
                this.UpdateCaretInfo();
            }
            /// <summary>
            /// The update caret info.
            /// </summary>
            private void UpdateCaretInfo()
            {
                var caretRect =
                    rtb.CaretPosition.GetCharacterRect(LogicalDirection.Forward);
                tb.Text = caretRect.ToString();
                rect.Margin = new Thickness(
                    caretRect.Right, 
                    caretRect.Bottom, 
                    -caretRect.Right, 
                    -caretRect.Bottom);
            }
            private void RtbTextChanged(object sender, TextChangedEventArgs e)
            {
                this.UpdateCaretInfo();
            }
        }
    }
