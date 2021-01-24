    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="2*" />
            <RowDefinition Height="1*" />
        </Grid.RowDefinitions>
        <Expander Grid.Row="0" IsExpanded="False" Background="Yellow" Margin="50,50,200,50" >
            <Expander.Style>
                <Style>
                    <Setter Property="Expander.IsEnabled" Value="False" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=Flag}" Value="True">
                            <Setter Property="Expander.IsEnabled" Value="True" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Expander.Style>
            <Grid Background="Yellow">
                <Grid.ColumnDefinitions>
                    <ColumnDefinition Width="100" />
                    <ColumnDefinition Width="100" />
                    <ColumnDefinition Width="100" />
                    <ColumnDefinition Width="100" />
                    <ColumnDefinition Width="100" />
                </Grid.ColumnDefinitions>
                <TextBlock Grid.Column="0" Text="Filters" />
                <CheckBox Grid.Column="1" Content="A"/>
                <CheckBox Grid.Column="2" Content="B"/>
                <CheckBox Grid.Column="3" Content="C"/>
            </Grid>
        </Expander>
        <Button Grid.Row="1" Click="ButtonClick" Content="Click Me" />
    </Grid>
