    <DataGrid Name="PredicateStatementDataGrid" GridLinesVisibility="All"  
              HeadersVisibility="All" AutoGenerateColumns="false">
        <DataGrid.Columns>
            <DataGridTemplateColumn Header="ID #" Width="35" IsReadOnly="True"
                Binding="{Binding IdProperty}">
            </DataGridTemplateColumn>
            <DataGridTemplateColumn Header="Predicate Statement" Width="300" 
                Binding="{Binding PredictateProperty}">
                IsReadOnly="True">
            </DataGridTemplateColumn>
        </DataGrid.Columns>
    </DataGrid>
