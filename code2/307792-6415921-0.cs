    <Window x:Class="WpfApplication1.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml" xmlns:system="clr-namespace:System.Collections;assembly=mscorlib"  xmlns:local="clr-namespace:WpfApplication1"  Title="MainWindow" Height="350" Width="525">
        <Window.Resources>
            <local:MiniObject x:Key="RootItem" Caption="Item0" Checked="True">
                <local:MiniObject.Content>
                    <system:ArrayList>  -------------------------------------1)
                        <local:MiniObject Caption="Item1" Checked="True">
                        </local:MiniObject>
                        <local:MiniObject Caption="Item2" Checked="True">
                        </local:MiniObject>
                    </system:ArrayList>
                </local:MiniObject.Content>
            </local:MiniObject>
        </Window.Resources>
        <Grid>
            <ListBox ItemsSource="{Binding Source={StaticResource ResourceKey=RootItem}, Path=Content}" DisplayMemberPath="Caption"/>
        </Grid>
    </Window>
    public class MiniObject
    {
        public bool Checked { get; set; }
        public String Caption { get; set; }
        public IList Content { get; set; } -----------------------------------------2)
    }
