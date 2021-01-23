    <ItemsControl ItemsSource="{Binding PersonList}">
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <HeaderedContentControl>
                    <HeaderedContentControl.Header>
                        <TextBlock Text="{Binding PersonName}" Foreground="Blue" />
                    </HeaderedContentControl.Header>
                    <ItemsControl ItemsSource="{Binding FriendList}">
                        <ItemsControl.ItemTemplate>
                            <DataTemplate>
                                <TextBlock Text="{Binding Name}" />
                            </DataTemplate>
                        </ItemsControl.ItemTemplate>
                    </ItemsControl>
                </HeaderedContentControl>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
