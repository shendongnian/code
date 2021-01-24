    <Grid Name="grid">
        <Grid.RowDefinitions>
            <RowDefinition Height="20"/>
            <RowDefinition/>
        </Grid.RowDefinitions>
        <Grid Grid.Row="0">
            <Grid.ColumnDefinitions>
                <ColumnDefinition Width="250"/>
                <ColumnDefinition/>
            </Grid.ColumnDefinitions>
            <Button Grid.Column="0" Content="Add New FlipView Item" Click="Button_Click"/>
            <DockPanel Grid.Column="1">
                <TextBlock>Flipview Item Count : </TextBlock>
                <TextBlock Text="{Binding ModelItems.Count}"/>
            </DockPanel>
        </Grid>
        <FlipView Grid.Row="1" Name="flipView" ItemsSource="{Binding ModelItems}">
            <FlipView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Vertical">
                        <DockPanel>
                            <TextBlock Text="Index:" FontSize="20"/>
                            <TextBlock Text="{Binding Index}" FontSize="60" />
                        </DockPanel>
                        <DockPanel>
                            <TextBlock Text="Name:" FontSize="20"/>
                            <TextBlock Text="{Binding Name}" FontSize="60" />
                        </DockPanel>
                    </StackPanel>
                </DataTemplate>
            </FlipView.ItemTemplate>
        </FlipView>
    </Grid>
