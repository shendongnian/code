    <DataGrid ItemsSource="{Binding MyDataView}" AutoGenerateColumns="False">
      <DataGrid.Columns>
        <DataGridTextColumn Header="Some Val" Binding="{Binding 'Some Val'}" Width="50" />
        <DataGridTextColumn Header="{Binding (FrameworkElement.DataContext).ColumnTitle, RelativeSource={x:Static RelativeSource.Self}}" Binding="{Binding Path=[Ref].Description}" />
      </DataGrid.Columns>
    </DataGrid>
