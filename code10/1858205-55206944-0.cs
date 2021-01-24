    <ItemsControl ItemsSource="{Binding Cells}">
        <ItemsControl.ItemsPanel>
            <ItemsPanelTemplate>
                <UniformGrid Columns="10"/>
            </ItemsPanelTemplate>
        </ItemsControl.ItemsPanel>
        <ItemsControl.ItemTemplate>
            <DataTemplate>
                <Rectangle>
                    <Rectangle.Fill>
                        <SolidColorBrush Color="{Binding Color}"/>
                    </Rectangle.Fill>
                </Rectangle>
            </DataTemplate>
        </ItemsControl.ItemTemplate>
    </ItemsControl>
