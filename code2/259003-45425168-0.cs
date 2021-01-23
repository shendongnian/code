        <DataGrid
                  AutoGenerateColumns="False"
                  ItemsSource="{Binding MyDictionary}">
            <DataGrid.Columns>
                <DataGridTextColumn Header="Key" Binding="{Binding Key}" />
                <DataGridTextColumn Header="Value" Binding="{Binding Value}" />
            </DataGrid.Columns>
        </DataGrid>
