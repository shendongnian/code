    <DataGrid Name="PredicateStatementDataGrid" GridLinesVisibility="All"  
              HeadersVisibility="All" AutoGenerateColumns="false">
        <DataGrid.RowStyle>
            <Style TargetType="DataGridRow">
                <Style.Triggers>
                    <DataTrigger Binding="{Binding IsBold}" Value="true">
                        <Setter Property="Fontweight" Value="Bold"/>
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        <DataGrid.Columns>
            <DataGridTextColumn Header="ID #" Width="35" IsReadOnly="True"
                Binding="{Binding ID}">
            </DataGridTextColumn>
            <DataGridTextColumn Header="Predicate Statement" Width="300" 
                Binding="{Binding Statement}">
                IsReadOnly="True">
            </DataGridTextColumn>
        </DataGrid.Columns>
    </DataGrid>
