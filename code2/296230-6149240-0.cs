    // KeyboardButton.cs
    /// <remarks>
    /// This class does contain a lot of more code which isn't related to the actual problem.
    /// </remarks>
    public partial class KeyboardButton
    {
    	[DefaultValue(Key.NoName)]
        public Key EmulatedKey { get; set; }
    }
    // KeyboardPanel.cs
    public class KeyboardButtonCollection : Collection<KeyboardButton> { }
    
    
    public static class KeyboardPanel
    {
        internal const string ButtonsPropertyName = "Buttons";
    
    
        static KeyboardPanel()
        {
            ButtonsProperty = DependencyProperty.RegisterAttached
            (
                ButtonsPropertyName,
                typeof(KeyboardButtonCollection),
                typeof(KeyboardPanel),
                new UIPropertyMetadata(null, OnButtonsChanged)
            );
        }
    
    
        public static KeyboardButtonCollection GetButtons(DependencyObject dependencyObject)
        {
            return (KeyboardButtonCollection)dependencyObject.GetValue(ButtonsProperty);
        }
    
        public static void SetButtons(DependencyObject dependencyObject, KeyboardButtonCollection value)
        {
            dependencyObject.SetValue(ButtonsProperty, value);
        }
    
    
        public static bool IsKeyboardPanel(DependencyObject dependencyObject)
        {
            return GetButtons(dependencyObject).Count != 0;
        }
    
    
        public static readonly DependencyProperty ButtonsProperty;
    
    
        private static void OnButtonsChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            bool isSupportedType = true;
    
            if (dependencyObject is Panel)
            {
                var panel = (Panel)dependencyObject;
                foreach (var button in (KeyboardButtonCollection)e.NewValue)
                    panel.Children.Add(button);
            }
            else
                isSupportedType = false;
    
            if (!isSupportedType)
                throw new NotSupportedException(string.Format("Type {0} is not supported as KeyboardPanel.", dependencyObject.GetType()));
        }
    }
    <!-- MainWindow.xaml -->
    <Grid>
        <controls:KeyboardPanel.Buttons>
            <controls:KeyboardButtonCollection>
                <controls:KeyboardButton Content="Enter" EmulatedKey="Enter"/>
                <controls:KeyboardButton Grid.Row="1" Content="Some Key"/>
                <controls:KeyboardButton Grid.Row="2" Content="Another Key"/>
            </controls:KeyboardButtonCollection>
        </controls:KeyboardPanel.Buttons>
            
        <Grid.RowDefinitions>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
            <RowDefinition/>
        </Grid.RowDefinitions>
            
        <Button Grid.Row="3" Content="Test" Loaded="Button_Loaded"/>
    </Grid>
    // MainWindow.xaml.cs
    public partial class MainWindow : Window
    {
        private void Button_Loaded(object sender, RoutedEventArgs e)
        {
            var button = (Button)sender;
            if (KeyboardPanel.IsKeyboardPanel(button.Parent))
            {
                var enterButton = KeyboardPanel.GetButtons(button.Parent)
                                               .FirstOrDefault(b => b.EmulatedKey == Key.Enter);
    
                if (enterButton != null)
                    MessageBox.Show("KeyboardPanel contains an EnterButton");
                else
                    MessageBox.Show("KeyboardPanel doesn't contain an EnterButton");
            }
        }
    }
