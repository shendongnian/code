    ObservableCollection<WindowInstance> _windows = new ObservableCollection<WindowInstance>();
    
    class WindowInstance
    {
        public Window CurrentWindowInstance { get; set; }
        public DependencyObject CurrentVisual {
            get {
                return VisualTreeHelper.GetChild(CurrentWindowInstance, 0);
            }
        }
    }
    
    <ItemsControl ItemsSource="{Binding}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel></StackPanel>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border BorderThickness="0,0,0,0" Width="50" Height="50">
                    <Border.Background>
                        <VisualBrush Visual="{Binding CurrentVisual}"/>
                    </Border.Background>
                </Border>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
