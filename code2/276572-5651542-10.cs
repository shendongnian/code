    <TabControl
        ItemsSource="{Binding Tabs}">
        <TabControl.ItemTemplate>
            <!-- this is the header template-->
            <DataTemplate>
                <TextBlock
                    Text="{Binding Header}" />
            </DataTemplate>
        </TabControl.ItemTemplate>
        <TabControl.ContentTemplate>
            <!-- this is the body of the TabItem template-->
            <DataTemplate>
                <MyUserControl xmlns="clr-namespace:WpfApplication12" />
            </DataTemplate>
        </TabControl.ContentTemplate>
    </TabControl>
