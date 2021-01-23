    <ListView>
        <ListView.ItemsPanel>
            <ItemsPanelTemplate>
                <Grid IsItemsHost="True">
                    <Grid.RowDefinitions>
                        <RowDefinition/>
                        <RowDefinition/>
                    </Grid.RowDefinitions>
                    <Grid.ColumnDefinitions>
                        <ColumnDefinition/>
                        <ColumnDefinition/>
                    </Grid.ColumnDefinitions>
                </Grid>
            </ItemsPanelTemplate>
        </ListView.ItemsPanel>
        <ListView.ItemContainerStyle>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="Grid.Column" Value="{Binding RelativeSource={RelativeSource Self}, Path=Content.(Grid.Column)}"/>
                <Setter Property="Grid.Row" Value="{Binding RelativeSource={RelativeSource Self}, Path=Content.(Grid.Row)}"/>
            </Style>
        </ListView.ItemContainerStyle>
        <ListView.ItemsSource>
            <x:Array Type="{x:Type sys:Object}">
                <TextBlock Grid.Column="0" Grid.Row="0" Text="Lorem"/>
                <TextBlock Grid.Column="1" Grid.Row="0" Text="Ipsum"/>
                <TextBlock Grid.Column="0" Grid.Row="1" Text="Dolor"/>
                <TextBlock Grid.Column="1" Grid.Row="1" Text="Sit"/>
            </x:Array>
        </ListView.ItemsSource>
    </ListView>
