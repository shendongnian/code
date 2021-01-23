      <ItemsControl ItemsSource="{Binding Images}" >
                                                <ItemsControl.ItemTemplate>
                                                    <DataTemplate>
                                                        <Image Source={Binding}></Image>
                                                    </DataTemplate>
                                                </ItemsControl.ItemTemplate>
                                                <ItemsControl.ItemsPanel>
                                                    <ItemsPanelTemplate>
                                                        <Stackpanle Orientation="Horizontal" IsItemsHost="True" />
                                                    </ItemsPanelTemplate>
                                                </ItemsControl.ItemsPanel>
                                            </ItemsControl>
 
