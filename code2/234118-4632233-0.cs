    <Grid>
        <StackPanel Orientation="Horizontal">
            <TabControl x:Name="tabControl1">
                <TabItem Header="Tab1"/>
                <TabItem Header="Tab2"/>
                <TabItem Header="Tab3"/>
                <TabItem Header="Tab4"/>
            </TabControl>
            <ListBox ItemsSource="{Binding Items, ElementName=tabControl1}">
                <ListBox.ItemTemplate>
                    <DataTemplate>
                        <TextBlock Text="{Binding Header}"/>
                    </DataTemplate>
                </ListBox.ItemTemplate>
            </ListBox>
        </StackPanel>
    </Grid>
