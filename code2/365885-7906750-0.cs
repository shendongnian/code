    <ItemsControl ItemsSource="{Binding Days}">
        <!-- ItemsPanelTemplate -->
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid>
                    <Grid.RowDefinitions>
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                        <RowDefinition />
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                        <ColumnDefinition />
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
    
        <!-- ItemContainerStyle -->
        <ItemsControl.ItemContainerStyle>
            <Style>
                <Setter Property="Grid.Column" Value="{Binding DayOfWeek}" />
                <Setter Property="Grid.Row" Value="{Binding WeekNo}" />
            </Style>
        </ItemsControl.ItemContainerStyle>
    </ItemsControl>
