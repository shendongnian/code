                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <Ellipse Width="{Binding Width}" Height="{Binding Height}" Fill="{Binding DisplayColor}" Tag="{Binding RelativeSource={RelativeSource AncestorType={x:Type Window}}, Path=DataContext}">
                                    <Ellipse.ContextMenu>
                                        <ContextMenu>
                                            <MenuItem Header="Menu item 2" Command="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType={x:Type ContextMenu}}, Path=PlacementTarget.Tag.TestClick}" CommandParameter="{Binding}"/>
                                        </ContextMenu>
                                    </Ellipse.ContextMenu>
                                </Ellipse>
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
