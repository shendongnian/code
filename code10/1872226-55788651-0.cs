      <StackPanel Grid.Row="0" Grid.Column="1">
            <ItemsControl ItemsSource="{Binding Path=CBItems}">
                <ItemsControl.ItemsPanel>
                    <ItemsPanelTemplate>
                        <StackPanel Orientation="Horizontal"/>
                    </ItemsPanelTemplate>
                </ItemsControl.ItemsPanel>
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <CheckBox IsChecked="{Binding Path=CheckBoxChecked, Mode=TwoWay}" Command="{Binding Path=DataContext.CheckBoxChanged, RelativeSource={RelativeSource AncestorType=ItemsControl}}"/>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
            <Label Content="{Binding LabelContent}"></Label>
        </StackPanel>
