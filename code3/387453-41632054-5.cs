    <DataGrid CanUserAddRows="False" AutoGenerateColumns="False" ItemsSource="{Binding DataItems}">
        <DataGrid.Columns>
            <DataGridTextColumn Binding="{Binding Parameters[0].Value}" Header="P1">
                <DataGridTextColumn.CellStyle>
                    <Style TargetType="DataGridCell">
                        <Setter Property="Background" Value="Aqua" />
                        <Style.Triggers>
                            <DataTrigger Value="False">
                                <!-- Bind to Items with changing properties -->
                                <DataTrigger.Binding>
                                    <MultiBinding Converter="{StaticResource ParameterCompareConverter}">
                                        <Binding Path="DefaultParameters[0]" />
                                        <Binding Path="Parameters[0]" />
                                    </MultiBinding>
                                </DataTrigger.Binding>
                                <Setter Property="Background" Value="DeepPink" />
                            </DataTrigger>
                            <!-- Binds to AItem directly -->
                            <DataTrigger Value="True" Binding="{Binding Converter={StaticResource CheckParametersConverter}}">
                                <Setter Property="FontWeight" Value="ExtraBold" />
                            </DataTrigger>
                        </Style.Triggers>
                    </Style>
                </DataGridTextColumn.CellStyle>
            </DataGridTextColumn>
