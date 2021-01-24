    <CollectionView ItemsSource="{Binding Sets}">
        <CollectionView.ItemsLayout>
            <GridItemsLayout Orientation="Vertical" />
        </CollectionView.ItemsLayout>
        <CollectionView.ItemTemplate>
            <DataTemplate>
                <ScrollView x:Name="ParentCollection" Orientation="Horizontal">
                    <StackLayout BindableLayout.ItemsSource="{Binding Pictures}" Orientation="Horizontal">
                        <BindableLayout.ItemTemplate>
                            <DataTemplate>
                                <ff:CachedImage Aspect="AspectFill" Source="{Binding imageSource}">
                                    <ff:CachedImage.GestureRecognizers>
                                        <TapGestureRecognizer Command="{Binding ImageClickCommand}" CommandParameter="{Binding BindingContext.Id, Source={x:Reference Name=ParentCollection}}"/>
                                    </ff:CachedImage.GestureRecognizers>
                                 </ff:CachedImage>
                            </DataTemplate>
                        </BindableLayout.ItemTemplate>
                    </StackLayout>
                </ScrollView>
            </DataTemplate>
        </CollectionView.ItemTemplate>
    </CollectionView>
