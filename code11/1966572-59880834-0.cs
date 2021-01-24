    <ListView ItemsSource="{Binding Cities}">
            <ListView.ItemTemplate>
                <DataTemplate>
                    <StackPanel Orientation="Horizontal">
                        <Label Content="{Binding CityName}" />
                            <CheckBox IsChecked="{Binding IsChecked}">
                                <i:Interaction.Triggers>
                                    <i:EventTrigger EventName="Checked">
                                        <i:InvokeCommandAction Command="{Binding DataContext.SelectedCitiesChangedCommand, RelativeSource={RelativeSource AncestorType=ListView}}"/>
                                    </i:EventTrigger>
                                    <i:EventTrigger EventName="Unchecked">
                                        <i:InvokeCommandAction Command="{Binding DataContext.SelectedCitiesChangedCommand, RelativeSource={RelativeSource AncestorType=ListView}}"/>
                                    </i:EventTrigger>
                                </i:Interaction.Triggers>
                            </CheckBox>
                    </StackPanel>
                </DataTemplate>
            </ListView.ItemTemplate>
        </ListView>
