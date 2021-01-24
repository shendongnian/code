    <Window.Resources>
        <h:BindingProxy x:Key="proxy" Data="{Binding}"></h:BindingProxy>
    </Window.Resources>
    <Grid>
    <ItemsControl ItemsSource="{Binding MyData}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Grid>
                    <Grid.ColumnDefinitions>
                         <ColumnDefinition></ColumnDefinition>
                         <ColumnDefinition></ColumnDefinition>
                    </Grid.ColumnDefinitions>
                    <Grid.ContextMenu>
                        <ContextMenu>
                            <MenuItem Header="Remove Me" Command="{Binding Data.MyCommand, Source={StaticResource proxy}}" CommandParameter="{Binding}"></MenuItem>
                       </ContextMenu>
                    </Grid.ContextMenu>
                   <TextBlock Grid.Column="0" HorizontalAlignment="Center" VerticalAlignment="Center" Text="{Binding SomeField}"></TextBlock>
               </Grid>
           </DataTemplate>
        </ItemsControl.ItemTemplate>
     </ItemsControl>
     </Grid>
