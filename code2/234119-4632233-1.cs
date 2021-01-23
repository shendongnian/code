    <Grid>
        <Grid.ColumnDefinitions>
            <ColumnDefinition Width="Auto"/>
            <ColumnDefinition Width="*"/>
        </Grid.ColumnDefinitions>
        <TabControl Grid.Column="0" Name="tabControl1">
            <TabItem Header="Tab1"/>
            <TabItem Header="Tab2"/>
            <TabItem Header="Tab3"/>
            <TabItem Header="Tab4"/>
        </TabControl>
        <ListBox Grid.Column="1"  ItemsSource="{Binding Items, ElementName=tabControl1}">
            <ListBox.ItemContainerStyle>
                <Style TargetType="{x:Type ListBoxItem}" BasedOn="{StaticResource {x:Type ListBoxItem}}">
                    <EventSetter Event="MouseDoubleClick" Handler="ListBoxItem_DoubleClick"/>
                </Style>
            </ListBox.ItemContainerStyle>
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <TextBlock Text="{Binding Header}"/>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
