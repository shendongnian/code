    <Grid>
        <Grid.Resources>
            <BooleanToVisibilityConverter x:Key="b2v" />
        </Grid.Resources>
        <Grid.RowDefinitions>
            <RowDefinition />
            <RowDefinition />
        </Grid.RowDefinitions>
    
        <ToggleButton Grid.Row="0"  IsChecked="{Binding IsButtonVisible, Mode=TwoWay}">Click Me</ToggleButton>
    
        <ListBox Grid.Row="1" Visibility="{Binding IsButtonVisible, Converter={StaticResource b2v}}">
            <ListBox.Items>
                <ListBoxItem>London</ListBoxItem>
                <ListBoxItem>New York</ListBoxItem>
                <ListBoxItem>Paris</ListBoxItem>
            </ListBox.Items>
        </ListBox>
    </Grid>
