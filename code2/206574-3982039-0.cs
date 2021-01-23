    <DataGrid AutoGenerateColumns="False" Height="311" HorizontalAlignment="Left" Name="dataGrid1" VerticalAlignment="Top" ItemsSource="{Binding Bytes}" Width="503">
            <DataGrid.Columns>
                <DataGridTextColumn Header="1" Binding="{Binding Piece[0]}"></DataGridTextColumn>
                <DataGridTextColumn Header="2" Binding="{Binding Piece[1]}"></DataGridTextColumn>
                <DataGridTextColumn Header="3" Binding="{Binding Piece[2]}"></DataGridTextColumn>
                <DataGridTextColumn Header="4" Binding="{Binding Piece[3]}"></DataGridTextColumn>
                <DataGridTextColumn Header="5" Binding="{Binding Piece[4]}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
