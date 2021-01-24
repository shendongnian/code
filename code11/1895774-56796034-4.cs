     <DataGrid x:Name="BlueprintsDataGrid" Grid.Row="0" IsReadOnly="True" 
                  ItemsSource="{Binding Path=Game.Blueprints, ElementName=uc}" 
                  SelectedItem="{Binding CurrentSelection}"
                  AutoGenerateColumns="False">
     <i:Interaction.Triggers>
                <i:EventTrigger EventName="MouseDoubleClick">
                    <i:InvokeCommandAction Command="{Binding DoubleClickedCommand}"/>
                </i:EventTrigger>
            </i:Interaction.Triggers>
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Width="80*" Binding="{Binding Name}"/>
                <DataGridTextColumn Header="ME" Width="30*" Binding="{Binding MaterialEfficiency}"
                                    HeaderStyle="{StaticResource HeaderRightJustify}"
                                    CellStyle="{StaticResource ColumnRight}"/>
                <DataGridCheckBoxColumn Header="BPO" Width="30*" Binding="{Binding IsOrginial}"
                                        HeaderStyle="{StaticResource HeaderRightJustify}"/>
            </DataGrid.Columns>
        </DataGrid>
