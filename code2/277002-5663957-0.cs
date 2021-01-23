    <DataTemplate x:Key="MachinesTemplate">
        <Grid>
            <Grid.ColumnDefinitions>
                <ColumnDefinition/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <CheckBox Content="{Binding XPath=HostName}" Margin="1"
                      IsChecked="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ListBoxItem}}, Path=IsSelected}"/>
        </Grid>
    </DataTemplate>
