    <ContentPage>
     <ContentPage.Resources>
        <ResourceDictionary>
            <local:GetListConverter x:Key="getList" />
        </ResourceDictionary>
     </ContentPage.Resources>
    
     <StackLayout Padding="10, 0">
        <Entry x:Name="entry1"
               Text=""
               Placeholder="enter search term"
               VerticalOptions="CenterAndExpand" />
        <ListView ItemsSource="{Binding Source={x:Reference entry1},
                                    Path=Text,
                                    Converter={StaticResource getList}}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <ViewCell>
                        <Entry Text="{Binding .}"></Entry>
                    </ViewCell>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
     </StackLayout>
    </ContentPage>  
