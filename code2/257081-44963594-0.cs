    <Border x:Name="border" />
    <ComboBox>
        <ComboBox.ItemsSource>
            <Binding>
                <Binding.Source>
                    <CollectionViewSource Source="{Binding Path=DataContext.Configurations, Source={x:Reference border}}">
                        <CollectionViewSource.SortDescriptions>
                            <scm:SortDescription PropertyName="AgencyName" />
                        </CollectionViewSource.SortDescriptions>
                    </CollectionViewSource>
                </Binding.Source>
            </Binding>
        </ComboBox.ItemsSource>
    </ComboBox>
