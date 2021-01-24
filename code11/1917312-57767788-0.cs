    <Window>
      <Window.Resources>
    
        <CollectionViewSource x:Key="MainCollectionViewSource"
                              Source="{Binding RelativeSource={RelativeSource FindAncestor, AncestorType=local:SecondWindow}, Path=MainList}">
          <CollectionViewSource.GroupDescriptions>
            <PropertyGroupDescription PropertyName="Key" />
          </CollectionViewSource.GroupDescriptions>
        </CollectionViewSource>
      </Window.Resources>
    
      <ListView ItemsSource="{Binding Source={StaticResource MainCollectionViewSource}}">    
        <ListView.ItemTemplate>
          <DataTemplate DataType="ListObj">
    
            <Grid>
              <Grid.Resources>
    
                <CollectionViewSource x:Key="SubCollectionViewSource"
                                      Source="{Binding SubList}">
                  <CollectionViewSource.GroupDescriptions>
                    <PropertyGroupDescription PropertyName="id" />
                  </CollectionViewSource.GroupDescriptions>
                </CollectionViewSource>
              </Grid.Resources>
              <Grid.RowDefinitions>
                <RowDefinition Height="20" />
                <RowDefinition />
              </Grid.RowDefinitions>
    
              <TextBlock Grid.Row="0"
                         Text="{Binding Value}" />
    
              <ListView Grid.Row="1"
                        ItemsSource="{Binding Source={StaticResource SubCollectionViewSource}}">
                <ListView.ItemTemplate>
                  <DataTemplate DataType="SubListObj">
    
                    <Grid>
                      <TextBlock Text="{Binding name}" />
                    </Grid>
                  </DataTemplate>
                </ListView.ItemTemplate>
                <ListView.GroupStyle>
                  <GroupStyle>
                    <GroupStyle.HeaderTemplate>
                      <DataTemplate DataType="GroupItem">
                        <TextBlock FontWeight="Bold"
                                   FontSize="14"
                                   Text="{Binding Name}" />
                      </DataTemplate>
                    </GroupStyle.HeaderTemplate>
                  </GroupStyle>
                </ListView.GroupStyle>
              </ListView>
            </Grid>
          </DataTemplate>
        </ListView.ItemTemplate>
        <ListView.GroupStyle>
          <GroupStyle>
            <GroupStyle.HeaderTemplate>
              <DataTemplate DataType="GroupItem">
    
                <TextBlock FontWeight="Bold"
                           FontSize="14"
                           Text="{Binding Name}" />
              </DataTemplate>
            </GroupStyle.HeaderTemplate>
          </GroupStyle>
        </ListView.GroupStyle>
      </ListView>
    </Window>
