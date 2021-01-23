    <DataGrid Name="TablaTestGrid" Grid.Row="1" AutoGenerateColumns="False"                    
                  CurrentCellChanged="TablaTestGrid_CurrentCellChanged">
            <DataGrid.Columns>
                <DataGridTextColumn Header="ID" Binding="{Binding Path=IdTablaTest}" IsReadOnly="True"></DataGridTextColumn>
                <DataGridTextColumn Header="Col A" Binding="{Binding Path=ColumnaA}"></DataGridTextColumn>
                <DataGridTextColumn Header="Col B" Binding="{Binding Path=ColumnaB}"></DataGridTextColumn>
                <DataGridTextColumn Header="A/B" Binding="{Binding Path=ColumnaC}" IsReadOnly="True" ></DataGridTextColumn>               
                <DataGridTextColumn Header="TestOnly"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
