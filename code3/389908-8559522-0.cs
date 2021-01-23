    <TabControl
            ItemsSource="{Binding Workspaces}" 
            SelectedItem="{Binding CurrentPage, Mode=TwoWay}" 
            SelectedIndex="{Binding SelectedWorkspace, UpdateSourceTrigger=PropertyChanged}">
        <TabControl.ItemTemplate>
            <DataTemplate>
                <DockPanel>
                      <TextBlock Text="{Binding Header}" HorizontalAlignment="Center" VerticalAlignment="Center"/>
                </DockPanel>
            </DataTemplate>
        </TabControl.ItemTemplate>
    </TabControl>
