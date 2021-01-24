    public MainWindow()
    {
        InitializeComponent();
    
        lst.ItemsSource = new List<DataContainer>
        {
            new DataContainer(1, "At: 0,0"),
            new DataContainer(2, "At: 1,0"),
            new DataContainer(3, "At: 2,0"),
            new DataContainer(4, "At: 0,1"),
            new DataContainer(5, "At: 1,1"),
            new DataContainer(6, "At: 2,1")
        }
    }
    <ItemsControl x:Name="lst" ItemTemplate="{DynamicResource DataTemplate_Level2}">
       <ItemsControl.ItemsPanel>
          <ItemsPanelTemplate>
             <UniformsGrid Columns="3" Rows="2"/>
          </ItemsPanelTemplate>
       </ItemsControl.ItemsPanel>
    </ItemsControl>
