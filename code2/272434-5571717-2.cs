    <Window x:Class="CellSelection.MainWindow"
            xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
            xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
            Title="MainWindow" Height="350" Width="525">
        <Grid>
            <Grid.RowDefinitions>
                <RowDefinition Height="275*" />
                <RowDefinition Height="36*" />
            </Grid.RowDefinitions>
            <DataGrid ItemsSource="{Binding}" AutoGenerateColumns="False"
                      SelectionMode="Extended" SelectionUnit="CellOrRowHeader">
                <DataGrid.Columns>
                
                    <DataGridTextColumn Header="Id" Binding="{Binding Id}">
                        <DataGridTextColumn.CellStyle>
                            <Style TargetType="DataGridCell">
                                <Setter Property="IsSelected">
                                    <Setter.Value>
                                        <Binding Path="IsIdSelected" Mode="TwoWay"
                                                 UpdateSourceTrigger="PropertyChanged"/>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </DataGridTextColumn.CellStyle>
                    </DataGridTextColumn>
                
                    <DataGridTextColumn Header="Name" Binding="{Binding Name}">
                        <DataGridTextColumn.CellStyle>
                            <Style TargetType="DataGridCell">
                                <Setter Property="IsSelected">
                                    <Setter.Value>
                                        <Binding Path="IsNameSelected" Mode="TwoWay"
                                                 UpdateSourceTrigger="PropertyChanged"/>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </DataGridTextColumn.CellStyle>
                    </DataGridTextColumn>
                
                    <DataGridTextColumn Header="Address" Binding="{Binding Address}">
                        <DataGridTextColumn.CellStyle>
                            <Style TargetType="DataGridCell">
                                <Setter Property="IsSelected">
                                    <Setter.Value>
                                        <Binding Path="IsAddressSelected" Mode="TwoWay"
                                                 UpdateSourceTrigger="PropertyChanged"/>
                                    </Setter.Value>
                                </Setter>
                            </Style>
                        </DataGridTextColumn.CellStyle>
                    </DataGridTextColumn>
                </DataGrid.Columns>
            </DataGrid>
            <Button Content="Export Selection" Grid.Row="1" HorizontalAlignment="Right"
                    Click="OnExportButtonClick" Margin="5"/>
        </Grid>
    </Window>
