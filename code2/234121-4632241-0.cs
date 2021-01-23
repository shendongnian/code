    <TabControl Name="MyTabControl">
        <TabItem Header="Tab1">
        </TabItem>
        <TabItem Header="Tab2">
        </TabItem>
    </TabControl>
       
    <ListView  DockPanel.Dock="Left" 
               ItemsSource="{Binding ElementName=MyTabControl, Path=Items}" 
               DataContext="{Binding}">
              <ListView.ItemTemplate>
                  <DataTemplate>
                      <TextBlock Text="{Binding Header}"></TextBlock>
                  </DataTemplate>
              </ListView.ItemTemplate>
    </ListView>
