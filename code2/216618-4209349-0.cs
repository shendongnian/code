    <Grid Name="MainGrid">
        
        <DataGrid ItemsSource="{Binding Programs}" IsReadOnly="True" AutoGenerateColumns="false" >
            <DataGrid.Columns>
                <DataGridTextColumn Header="Name" Binding="{Binding Name}"/>
                <DataGridTextColumn Header="Version" Binding="{Binding Version}"/>
                <DataGridTextColumn Header="Publisher" Binding="{Binding Publisher}"/>
            </DataGrid.Columns>
        </DataGrid>
        <Button Name="ButtonExpand" Margin="0,0,20,20" Height="25" Width="25" HorizontalAlignment="Right" VerticalAlignment="Bottom" Content="+">
            <Button.Style>
                <Style TargetType="Button">
                    <Setter Property="Visibility" Value="Hidden"/>
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding ElementName=MainGrid,
                                               Path=IsMouseOver}" 
                             Value="True">
                            <Setter Property="Visibility" Value="Visible" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Button.Style>
        </Button>
    </Grid>
