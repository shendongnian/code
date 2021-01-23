    <ItemsControl ItemsSource="{Binding items}">
        <ItemsControl.ItemTemplate>
            <DataTemplate DataType="{x:Type local:Class1}">
                <Grid Height="{Binding YourHeightValue}">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="1*"/>
                        <ColumnDefinition Width="1*"/>
                        <ColumnDefinition Width="1*"/>
                    </Grid.ColumnDefinitions>
                    <TextBlock Grid.Column="0" Text="{Binding prop1}"/>
                    <TextBlock Grid.Column="1" Text="{Binding prop2}"/>
                    <TextBlock Grid.Column="2" Text="{Binding prop3}"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <StackPanel IsItemsHost="True"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    </ItemsControl>
