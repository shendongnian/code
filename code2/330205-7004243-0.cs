        <Window x:Class="Gabe2a.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:diag="clr-namespace:System.Diagnostics;assembly=WindowsBase"
        DataContext="{Binding Source={x:Static Application.Current}}"
        Title="Gabriel Main" Height="600" Width="800" KeyDown="Window_KeyDown">
        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            // Debug.WriteLine("Main Window Window_KeyDown " + e.Key.ToString());
            e.Handled = false;
            if (e.KeyboardDevice.Modifiers == ModifierKeys.Alt) //  && e.KeyboardDevice.IsKeyDown(Key.RightAlt))
            {
                if (e.Key == Key.System && e.SystemKey == Key.N)
                {
                    e.Handled = true;
                    App.StaticGabeLib.Search.NextDoc();
                }
                else if (e.Key == Key.System && e.SystemKey == Key.P)
                {
                    e.Handled = true;
                    App.StaticGabeLib.Search.PriorDoc();
                }
            }
            base.OnKeyDown(e);
        }
