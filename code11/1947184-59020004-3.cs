                <DataGrid x:Name="month_record"  MouseDoubleClick="month_record_MouseDoubleClick"
                                  IsReadOnly="True" Grid.ColumnSpan="9" Grid.Column="1" SelectionMode="Extended" 
                                  SelectionUnit="Cell" VerticalGridLinesBrush="Silver" HorizontalGridLinesBrush="Silver" 
                                  AutoGenerateColumns="False" ScrollViewer.VerticalScrollBarVisibility="Visible" 
                                  ScrollViewer.HorizontalScrollBarVisibility="Visible" Visibility="Visible" Grid.Row="4">
                            <DataGrid.Columns>
                                <DataGridTextColumn Binding="{Binding Sunday}" 
                                                    IsReadOnly="True" x:Name="colMSun" Header="Sunday" Width="Auto">
                                    <DataGridTextColumn.ElementStyle>
                                        <Style TargetType="{x:Type TextBlock}">
                                            <Style.Triggers>
                                                <Trigger Property="Text" Value="Sunday">
                                                    <Setter Property="Background" Value="Red"/>
                                                </Trigger>
                                            </Style.Triggers>
                                        </Style>
                                    </DataGridTextColumn.ElementStyle>
                                </DataGridTextColumn>
                  </DataGrid.Columns>
                        </DataGrid>
            }
     
    
