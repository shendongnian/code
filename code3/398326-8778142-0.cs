    <sdk:DataGrid ItemsSource="{Binding Items}" 
       AutoGenerateColumns="False" 
       RowDetailsVisibilityMode="Collapsed">
       <sdk:DataGrid.Resources>
         <SL5:VisibilityToBoolConverter x:Key="converter"/>
       </sdk:DataGrid.Resources>
       <sdk:DataGrid.Columns>
          <sdk:DataGridTemplateColumn>
             <sdk:DataGridTemplateColumn.CellTemplate>
                <DataTemplate>
                  <ToggleButton Content="Expand" 
                      IsChecked="{Binding Path=DetailsVisibility, 
                      Mode=TwoWay, 
                      RelativeSource={RelativeSource AncestorType=sdk:DataGridRow},
                      Converter={StaticResource converter}}"/>
                </DataTemplate>
              </sdk:DataGridTemplateColumn.CellTemplate>
           </sdk:DataGridTemplateColumn>
       </sdk:DataGrid.Columns>
    </sdk:DataGrid>
