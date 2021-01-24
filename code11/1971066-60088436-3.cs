    <StackPanel>
      <Button Content="Show All Hidden Rows"  
              Click="ShowAllRows_OnButtonClicked" />
      <DataGrid x:Name="MyDataGrid">
        <DataGrid.Columns>
          <DataGridTemplateColumn Header="Hide Row">
            <DataGridTemplateColumn.CellTemplate>
              <DataTemplate>
                <Button Content="Hide Row"
                        Click="HideRow_OnButtonClicked" />
              </DataTemplate>
            </DataGridTemplateColumn.CellTemplate>
          </DataGridTemplateColumn>
        </DataGrid.Columns>    
      </DataGrid>
    </StackPanel>
