    <DataGridTextColumn Header="{lex:Loc material}" 
                        Binding="{Binding Material}" Width="Auto" MinWidth="75" 
                        ToolTipService.ShowDuration="99999" ToolTipService.InitialShowDelay="0">
        <DataGridTextColumn.CellStyle>
            <Style TargetType="DataGridCell" BasedOn="{StaticResource MaterialDesignDataGridCell}">
                <Setter Property="ToolTip">
                    <Setter.Value>
                        <Image Source="{Binding ProductImage}" Width="250" />
                    </Setter.Value>
                </Setter>
                <Style.Triggers>
                    <DataTrigger Binding="{Binding ProductImageExists}" Value="False">
                        <Setter Property="ToolTip" Value="{x:Null}" />
                    </DataTrigger>
                </Style.Triggers>
            </Style>
        </DataGridTextColumn.CellStyle>
    </DataGridTextColumn>
