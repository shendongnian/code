    <Window.DataContext>
        <local:MainWindowViewModel/>
    </Window.DataContext>
    <Grid>
        <ListBox ItemsSource="{Binding People}"
                 HorizontalContentAlignment="Stretch">
            <ListBox.ItemTemplate>
                <DataTemplate>
                    <Grid>
                        <Grid.ColumnDefinitions>
                            <ColumnDefinition Width="*"/>
                            <ColumnDefinition Width="100"/>
                        </Grid.ColumnDefinitions>
                     <TextBlock Text="{Binding LastName}"/>
                        <Button Content="Delete"
                                Command="{Binding DataContext.DeletePersonCommand, RelativeSource={RelativeSource AncestorType=ListBox}}"
                                CommandParameter="{Binding}"
                                Grid.Column="1"/>
                    </Grid>
                </DataTemplate>
            </ListBox.ItemTemplate>
        </ListBox>
    </Grid>
