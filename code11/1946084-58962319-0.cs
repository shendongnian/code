    <Window.Resources>
        <ContextMenu x:Key="MyContextMenu">
            
            <MenuItem Header="Remove"
                      Command="{Binding RemoveItem}"
                      CommandParameter="{Binding RelativeSource={RelativeSource AncestorType=ContextMenu}, Path=PlacementTarget.SelectedItem}" />
        </ContextMenu>
    </Window.Resources>
    <Grid>
        <ListView x:Name="itemsListView" ItemsSource="{Binding MyItems}">
            <ListView.Style>
                <Style TargetType="{x:Type ListView}">
                    <Setter Property="ContextMenu"
                            Value="{StaticResource MyContextMenu}" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding SelectedItem, ElementName=itemsListView}"
                                     Value="{x:Null}">
                            <Setter Property="ContextMenu"
                                    Value="{x:Null}" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </ListView.Style>
        </ListView>
    </Grid>
