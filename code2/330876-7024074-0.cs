    <ContentPresenter Content="{Binding ElementName=selector, Path=SelectedItem}" />
    <ComboBox x:Name="selector">
        <ComboBox.ItemContainerStyle>
            <Style TargetType="ComboBoxItem">
                <Setter Property="Visibility" Value="{Binding Path=IsSelected, Converter={StaticResource boolToVisibilityConverter}}" />
            </Style>
        </ComboBox.ItemContainerStyle>
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding SomeProperty}" />
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>ComboBoxItem
