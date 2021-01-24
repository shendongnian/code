    Color myTextColor = Color.White;
    public Color MyTextColor
    {
        get { return myTextColor; }
        set { SetProperty(ref myTextColor, value); }
    }
    <ListView x:Name="Main_Menu" ItemsSource="{Binding Planets}" CachingStrategy="RecycleElement">
        <ListView.ItemTemplate>
            <DataTemplate>
                <TextCell Text="{Binding Name}" TextColor="{Binding Source={x:Reference Main_Menu}, Path=BindingContext.MyTextColor}"/>
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
