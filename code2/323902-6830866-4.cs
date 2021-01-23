    <local:DataBaseSettings>
        <Grid>
            <DataGrid ItemsSource="{Binding Printers}">
                <DataGrid.Columns>
                    <DataGridComboBoxColumn Header="Drucker Typ" 
                        ItemsSource="{Binding RelativeSource={RelativeSource AncestorType={x:Type local:DataBaseSettings}}, Path=PrinterTypes}"
                        SelectedItem="{Binding PrinterType, Mode=TwoWay}" />
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
    </local:DataBaseSettings>
