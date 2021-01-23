    <Grid>
        <StackPanel>
            <ItemsControl ItemsSource="{Binding}">
                <ItemsControl.ItemTemplate>
                    <DataTemplate>
                        <RadioButton
                        GroupName="Value"
                        Content="{Binding Description}"
                        IsChecked="{Binding IsChecked, Mode=TwoWay}"/>
                    </DataTemplate>
                </ItemsControl.ItemTemplate>
            </ItemsControl>
            <TextBlock Text="{Binding SelectedItem}"/>
        </StackPanel>
    </Grid>
