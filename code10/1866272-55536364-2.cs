    <DataGrid Name="dgCollection" AutoGenerateColumns="False" ItemSource="{Binding GetCollection1"}>
            <DataGrid.Columns>
                <DataGridTextColumn Header="Key" DisplayMemberPath="{Binding Path=Key}">
                </DataGridTextColumn>
                <DataGridTextColumn Header="Value" DisplayMemberPath="{Binding Path=Value}" />
            </DataGrid.Columns>
            </DataGrid>
