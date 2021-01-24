     <ContentPage.Resources>
        <ResourceDictionary>
            <local:DropDownConverter x:Key="DropDownConverter" />
        </ResourceDictionary>
    </ContentPage.Resources>
    <StackLayout>
        <!-- Place new controls here -->
        <ListView Margin="0,20,0,0" ItemsSource="{Binding myModels}">
            <ListView.ItemTemplate>
                <DataTemplate >
                    <ViewCell>
                        <StackLayout IsVisible="{Binding IsVisible}" HeightRequest="{Binding RowHeight}" Padding="{Binding IndentPadding}">
                            <StackLayout Orientation="Horizontal">
                                <Label Text="{Binding Text}" />
                                <Picker  ItemsSource="{Binding DropdownOptions}" SelectedItem="{Binding Answer,Converter={StaticResource DropDownConverter}, Mode=TwoWay}"  WidthRequest="100" ></Picker>
                            </StackLayout>
                            <BoxView />
                        </StackLayout>
                    </ViewCell>
                </DataTemplate>
                
            </ListView.ItemTemplate>
            
        </ListView>
    </StackLayout>
