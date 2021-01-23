     <ComboBox>
            <ComboBox.ItemTemplate>
                <DataTemplate>
                    <ComboBoxItem>
                        <ComboBoxItem.Content>
                            <TextBlock Text="{Binding Path, UpdateSourceTrigger=LostFocus,BindsDirectlyToSource=True}"                        </ComboBoxItem.Content>
                    </ComboBoxItem>
                </DataTemplate>
            </ComboBox.ItemTemplate>
        </ComboBox>
