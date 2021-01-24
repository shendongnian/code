    <ListView x:Name="lstDummies">
        <ListView.Resources>
            <Style TargetType="{x:Type ListViewItem}">
                <Setter Property="Opacity" Value="0" />
                <Style.Triggers>
                    <EventTrigger RoutedEvent="Loaded">
                        <EventTrigger.Actions>
                            <BeginStoryboard>
                                <Storyboard>
                                    <DoubleAnimation Storyboard.TargetProperty="Opacity" From="0" To="1" Duration="0:0:2">
                                    </DoubleAnimation>
                                </Storyboard>
                            </BeginStoryboard>
                        </EventTrigger.Actions>
                    </EventTrigger>
                </Style.Triggers>
            </Style>
        </ListView.Resources>
        <ListView.ItemsPanel >
            <ItemsPanelTemplate >
                <UniformGrid VerticalAlignment="Top" HorizontalAlignment="Left" Columns="17"/>
            </ItemsPanelTemplate>
        </ListView.ItemsPanel>
        <ListView.ItemTemplate>
            <DataTemplate>
                <Rectangle Width="50" Height="50" Fill="Green" />
            </DataTemplate>
        </ListView.ItemTemplate>
    </ListView>
