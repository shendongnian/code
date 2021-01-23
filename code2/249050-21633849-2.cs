    <ItemsControl ItemsSource="{Binding Path=Parameters, UpdateSourceTrigger=PropertyChanged, Mode=TwoWay}" Margin="3" >
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition Width="Auto"/>
                        <ColumnDefinition Width="*"/>
                    </Grid.ColumnDefinitions>
                    <Label Grid.Column="0" Content="{Binding Path=Key}" Margin="3" />
                    <TextBox Grid.Column="1" Text="{Binding Path=Value.Value, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}" IsReadOnly="True" Margin="3" />
                </Grid>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
