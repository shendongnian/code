        <ListView Name="KnownImages" ItemsSource="{Binding FileViewModels}">
            <ListView.View>
                <GridView>
                    <GridViewColumn Header="Segments" Width="100">
                        <GridViewColumn.CellTemplate>
                            <DataTemplate DataType="local:FileViewModel">
                                <ItemsControl Width="auto" Height="auto" ItemsSource="{Binding Segments}">
                                    <ItemsControl.ItemsPanel>
                                        <ItemsPanelTemplate>
                                            <WrapPanel/>
                                        </ItemsPanelTemplate>
                                    </ItemsControl.ItemsPanel>
                                    <ItemsControl.ItemTemplate>
                                        <DataTemplate DataType="local:SegmentViewModel">
                                            <Line ToolTip="{Binding ToolTip}" X1="1" X2="1" Y1="{Binding YTop}" Y2="15" StrokeThickness="3" Stroke="{Binding Stroke}"/>
                                        </DataTemplate>
                                    </ItemsControl.ItemTemplate>
                                </ItemsControl>
                            </DataTemplate>
                        </GridViewColumn.CellTemplate>
                    </GridViewColumn>
                </GridView>
            </ListView.View>
        </ListView>
