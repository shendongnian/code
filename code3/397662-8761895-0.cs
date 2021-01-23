    <DataGrid AutoGenerateColumns="False">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Name}" />
            <DataGridTextColumn Binding="{Binding Value}" />
            <DataGridTextColumn Binding="{Binding Results[1]}" />
            <DataGridTextColumn Binding="{Binding Results[2]}" />
            ....
        </DataGrid.Columns>
    </DataGrid>
