    <Grid Name="LayoutRoot">
        <Grid.Resources>
            <local:DataContextSpy x:Key="dataContextSpy" />
        </Grid.Resources>
        <DataGrid ...>
            <DataGrid.Columns>
                <DataGridTemplateColumn Header="Junk">
                    <DataGridTemplateColumn.CellTemplate>
                        <DataTemplate>
                            <Button Content="{Binding Source={StaticResource dataContextSpy},
                                                      Path=DataContext.JUNK}"/>
                        </DataTemplate>
                    </DataGridTemplateColumn.CellTemplate>
                </DataGridTemplateColumn>
                <!-- More Columns.. -->
            </DataGrid.Columns>
        </DataGrid>
    </Grid>
