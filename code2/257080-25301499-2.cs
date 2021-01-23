     <ItemsControl
            infrastructure:BindingBridge.BridgeInstance="{StaticResource ImagesBindingBridge}">
            <ItemsControl.ItemsSource>
                <Binding>
                    <Binding.Source>
                        <CollectionViewSource
                                    Source="{Binding SourceElement.DataContext.Images, Source={StaticResource ImagesBindingBridge}, Mode=OneWay}">
                            <CollectionViewSource.SortDescriptions>
                                <componentModel:SortDescription PropertyName="Timestamp" Direction="Descending"/>
                            </CollectionViewSource.SortDescriptions>
                        </CollectionViewSource>
                    </Binding.Source>
                </Binding>
            </ItemsControl.ItemsSource>
        </ItemsControl>
