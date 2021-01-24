    <ResourceDictionary>
      <CollectionViewSource x:Key="CollectionViewSource" Source="{Binding Settings}">
          <CollectionViewSource.GroupDescriptions>
            <PropertyGroupDescription PropertyName="SettingsSectionName"/>
          </CollectionViewSource.GroupDescriptions>
      </CollectionViewSource>
    </ResourceDictionary>
    <ListView x:Name="ListView" ItemsSource="{Binding Source={StaticResource CollectionViewSource}}">
      <ListView.GroupStyle>
        <GroupStyle>
          <GroupStyle.HeaderTemplate>
            <DataTemplate>
              <TextBlock FontWeight="Bold"
                         FontSize="14"
                         Text="{Binding Name}" />
            </DataTemplate>
          </GroupStyle.HeaderTemplate>
        </GroupStyle>
      </ListView.GroupStyle>
    </ListView>
