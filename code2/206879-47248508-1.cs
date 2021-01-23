    <ComboBox ItemsSource="{Binding Source={StaticResource CarColors}}" SelectedValue="{Binding CarColor, Mode=TwoWay, UpdateSourceTrigger=PropertyChanged}">
        <ComboBox.ItemTemplate>
            <DataTemplate>
                <TextBlock Text="{Binding Converter={StaticResource CarColorConverter}}" />
            </DataTemplate>
        </ComboBox.ItemTemplate>
    </ComboBox>
