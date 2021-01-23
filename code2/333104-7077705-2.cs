    <DataGrid ...>
        <DataGrid.CellStyle>
            <Style TargetType="DataGridCell">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding RelativeSource={RelativeSource AncestorType={x:Type DataGridRow}},
                                                   Path=Tag}" Value="ChangedBackground">
                        <Setter Property="Background" Value="Transparent" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGrid.CellStyle>
        <!--...-->
    </DataGrid>
    private void button_Click(object sender, RoutedEventArgs e)
    {
        DataGridRow dataGridRow = dataGrid.ItemContainerGenerator.ContainerFromIndex(dataGrid.SelectedIndex) as DataGridRow;
        if (dataGridRow != null)
        {
            dataGridRow.Background = Brushes.Green;
            dataGridRow.Tag = "ChangedBackground";
        }
    }
