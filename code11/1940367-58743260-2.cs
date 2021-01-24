      <CollectionView
                x:Name="list1"
                ItemsLayout="VerticalList"
                ItemsSource="{Binding Items}"
                SelectionChanged="List1_SelectionChanged"
                SelectionMode="Single">
              
                <CollectionView.ItemTemplate>
                    <DataTemplate>
                        <StackLayout Orientation="Horizontal">
                            <Label
                                HorizontalOptions="StartAndExpand"
                                Text="{Binding DisplayName}"
                                TextColor="Fuchsia" />
                            <BoxView
                                HorizontalOptions="End"
                                IsVisible="{Binding Selected}"
                                Color="Fuchsia" />
                        </StackLayout>
                    </DataTemplate>
                </CollectionView.ItemTemplate>
            </CollectionView>
    public Page23 ()
		{
			InitializeComponent ();
            this.BindingContext = new collectionviewmodel();
		}
