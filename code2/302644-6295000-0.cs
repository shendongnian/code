    <StackPanel>
            <ComboBox ItemsSource="{Binding Items}">
                <ComboBox.ItemTemplate>
                    <DataTemplate>
                        <CheckBox Content="{Binding Name}" IsChecked="{Binding IsSelected}"/>
                    </DataTemplate>
                </ComboBox.ItemTemplate>
            </ComboBox>
            <Button Click="EvaluateSelectedItems">Show Selected</Button>
            <TextBlock>Selected Items</TextBlock>
            <ListBox ItemsSource="{Binding SelectedItems}" DisplayMemberPath="Name" Background="AliceBlue"/>
        </StackPanel>
