    <DataGrid CanUserAddRows="False" AutoGenerateColumns="False" ItemsSource="{Binding DataItems}">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Parameters[0].Value}" Header="P1">
                <DataGridTextColumn.CellStyle>
                    <Style TargetType="DataGridCell">
                        <Setter Property="Background" Value="Aqua" />
                        <Style.Triggers>
                            <DataTrigger Value="False">
                                <DataTrigger.Binding>
                                    <MultiBinding Converter="{StaticResource ParameterCompareConverter}">
                                        <Binding Path="DefaultParameters[0]" />
                                        <Binding Path="Parameters[0]" />
                                    </MultiBinding>
                                </DataTrigger.Binding>
                                <Setter Property="Background" Value="DeepPink" />
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </DataGridTextColumn.CellStyle>
            </DataGridTextColumn>
