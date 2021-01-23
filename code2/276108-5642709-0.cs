    <Grid>
        <Grid.Resources>
            <XmlDataProvider x:Key="HostsData" XPath="//Host">
                <x:XData>
                    <Hosts xmlns="">
                        <Host foo="aaa">
                            <usable>1</usable>
                        </Host>
                        <Host foo="bbb">
                            <usable>1</usable>
                        </Host>
                    </Hosts>
                </x:XData>
            </XmlDataProvider>
            <CollectionViewSource x:Key="cvs" Source="{Binding Source={StaticResource HostsData}}">
                <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="@foo" />
                </CollectionViewSource.GroupDescriptions>
            </CollectionViewSource>
            <DataTemplate x:Key="categoryTemplate">
                <TextBlock Text="{Binding Path=Name}" FontWeight="Bold" Background="Gold" Margin="0,5,0,0"/>
            </DataTemplate>
        </Grid.Resources>
        <ListBox Name="myList" ItemsSource="{Binding Source={StaticResource cvs}}">
            <ListBox.GroupStyle>
                <GroupStyle HeaderTemplate="{StaticResource categoryTemplate}" />
            </ListBox.GroupStyle>
        </ListBox>
    </Grid>
