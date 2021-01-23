    <Controls:DataGrid ItemsSource="{Binding UnderlyingData}"
                       AutoGenerateColumns="False"
                       HeadersVisibility="Column">
      <Controls:DataGrid.Columns>
        <Controls:DataGridTemplateColumn Header="Use?" SortMemberPath="Use">
          <Controls:DataGridTemplateColumn.CellTemplate>
            <DataTemplate>
              <CheckBox Style="{StaticResource DataGridCheckBoxStyle}" IsChecked="{Binding Spike}"
                        Click="CheckBox_Clicked"/>
            </DataTemplate>
          </Controls:DataGridTemplateColumn.CellTemplate>
        </Controls:DataGridTemplateColumn>              
      </Controls:DataGrid.Columns>
    </Controls:DataGrid>
