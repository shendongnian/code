    <ListView Margin="6" DataContext="{Binding ElementName=This}" ItemsSource="{Binding KPICollection}" Name="lvKPIView" Grid.ColumnSpan="2">
        <ListView.View>
            <GridView>
                <GridViewColumn Width="40" >
                    <GridViewColumnHeader Tag="KPIResult[0]" Content="{Binding KPICollection.KPIResults[0].Date}" />
                    <GridViewColumn.CellTemplate>
                        <DataTemplate>
                            <Grid>
                                <TextBlock Text="{Binding Path=KPIResults[0].Result}" />
                                <TextBox Text="{Binding Path=KPIResults[0].Result}" />
                            </Grid>
                        </DataTemplate>
                    </GridViewColumn.CellTemplate>
                </GridViewColumn>
            </GridView>
        </ListView.View>
    </ListView>
