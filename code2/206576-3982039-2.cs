    <DataGrid AutoGenerateColumns="False" Name="dataGrid1" ItemsSource="{Binding Bytes}" ColumnWidth="1*">
            <DataGrid.Columns>
                <DataGridTextColumn Header="1" Binding="{Binding Piece[0]}"></DataGridTextColumn>
                <DataGridTextColumn Header="2" Binding="{Binding Piece[1]}"></DataGridTextColumn>
                <DataGridTextColumn Header="3" Binding="{Binding Piece[2]}"></DataGridTextColumn>
                <DataGridTextColumn Header="4" Binding="{Binding Piece[3]}"></DataGridTextColumn>
                <DataGridTextColumn Header="5" Binding="{Binding Piece[4]}"></DataGridTextColumn>
                <DataGridTextColumn Header="6" Binding="{Binding Piece[5]}"></DataGridTextColumn>
                <DataGridTextColumn Header="7" Binding="{Binding Piece[6]}"></DataGridTextColumn>
                <DataGridTextColumn Header="8" Binding="{Binding Piece[7]}"></DataGridTextColumn>
                <DataGridTextColumn Header="9" Binding="{Binding Piece[8]}"></DataGridTextColumn>
                <DataGridTextColumn Header="10" Binding="{Binding Piece[9]}"></DataGridTextColumn>
            </DataGrid.Columns>
        </DataGrid>
