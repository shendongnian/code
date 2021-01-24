    <ItemsControl ItemsSource="{Binding DataList}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid Margin="5">
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="100" />
                        <ColumnDefinition Width="100" />
                    </Grid.ColumnDefinitions>
                    <Label Grid.Column="0" Content="{Binding Id}"/>
                    <TextBox Grid.Column="1" Text="{Binding Name, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}"/>
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
