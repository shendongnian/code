    <ItemsControl ItemsSource="{Binding Cells}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <UniformGrid Columns="10"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Border>
                    <Border.Background>
                        <SolidColorBrush Color="{Binding Color}"/>
                    </Border.Background>
                    <!-- optional child element here -->
                </Border>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
