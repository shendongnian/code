     <Grid >
            <DataGrid AutoGenerateColumns="False" Name="dgrid" SelectionChanged="dgrid_SelectionChanged">
                <DataGrid.Columns>
                    <DataGridTextColumn Header="ID" Binding="{Binding Path=id}"/>
                </DataGrid.Columns>
            </DataGrid>
        </Grid>
        
        dgrid.ItemsSource = ds.Tables[0].AsDataView();
