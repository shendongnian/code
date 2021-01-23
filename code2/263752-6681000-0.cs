    public static class Commands
    {
        public static readonly RoutedCommand CreateNew = new RoutedCommand("New", typeof(Commands));
        static Commands()
        {
            SomeCommand.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Control));
        }
    }
    ...
    // Wherever you want to create the MenuItem. "local" should be the namespace that
    // you delcared "Commands" in.
    <MenuItem Header="_New" Command="{x:Static local:Commands.CreateNew">
    ...
    // Wherever you want to process the command. I am assuming you want to do it in your 
    // main window, but you can do it anywhere in the route between your main window and 
    // the menu item.
    <Window.CommandBindings>
        <CommandBinding Command="{x:Static local:Commands.CreateNew"> Executed="CreateNew_Executed" />
    </Window.CommandBindings>
    ...
    // In the code behind for your main window (or whichever file you put the above XAML in)
    private void CreateNew(object sender, ExecutedRoutedEventArgs e)
    {
        ...
    }
