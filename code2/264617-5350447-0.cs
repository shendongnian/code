     <TabControl x:Name="TheTabControl" ItemsSource="{Binding XmlData}">
            <TabControl.ItemTemplate>
                <DataTemplate>
                    <TabItem Header="{Binding XmlHeader}">
                        <StackPanel Margin="10" Orientation="Horizontal">
                            <TextBlock Text="{Binding xmlContent}"/>
                        </StackPanel>
                    </TabItem>
                </DataTemplate>                
            </TabControl.ItemTemplate>
        </TabControl>
