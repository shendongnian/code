    public class Data
    {
      public bool IsChecked { get; set; }
      public string Value { get; set; }
    }
    
    public ObservableCollection<Data> Items { get; } = new ObservableCollection<Data>();
    
    private void Populate()
    {
      Items.Add(new Data() { IsChecked = true, Value = "One" });
      Items.Add(new Data() { IsChecked = true, Value = "One" });
      Items.Add(new Data() { IsChecked = true, Value = "Two" });
      Items.Add(new Data() { IsChecked = true, Value = "One" });
      Items.Add(new Data() { IsChecked = true, Value = "Three" });
      Items.Add(new Data() { IsChecked = true, Value = "One" });
      Items.Add(new Data() { IsChecked = true, Value = "One" });
    }
    <DataGrid HorizontalAlignment="Stretch" VerticalAlignment="Stretch" AutoGenerateColumns="False" ItemsSource="{Binding Items}">
      <DataGrid.Resources>
        <Style TargetType="{x:Type CheckBox}" x:Key="CheckBoxStyle">
          <Style.Triggers>
            <DataTrigger Binding="{Binding Value}" Value="One">
              <Setter Property="IsEnabled" Value="False" />
            </DataTrigger>
          </Style.Triggers>
        </Style>
      </DataGrid.Resources>
      <DataGrid.Columns>
        <DataGridCheckBoxColumn Binding="{Binding IsChecked}" ElementStyle="{StaticResource CheckBoxStyle}" />
        <DataGridTextColumn Binding="{Binding Value}" />
      </DataGrid.Columns>
    </DataGrid>
