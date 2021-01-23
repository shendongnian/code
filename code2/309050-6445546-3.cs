    <ItemsControl DataContext="{Binding ViewModel}"
                  ItemsSource="{Binding BudgetGroups}">
      <ItemsControl.ItemTemplate>
        <DataTemplate>
          <GroupBox Header="{Binding GroupName}">
            <ItemsControl ItemsSource="{Binding LineItems}">
              <ItemsControl.ItemTemplate>
                <DataTemplate>
                  <StackPanel Orientation="Horizontal">
                    <TextBlock Text="{Binding Name}" />
                    <TextBlock Text="{Binding Cost}" />
                  </StackPanel>
                </DataTemplate>
              </ItemsControl.ItemTemplate>
            </ItemsControl>
          </GroupBox>
        </DataTemplate>
      </ItemsControl.ItemTemplate>
    </ItemsControl>
