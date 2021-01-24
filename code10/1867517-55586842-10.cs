        <Expander Grid.Row="0"  Background="Yellow" Margin="50,50,200,50" >
            <Expander.Style>
                <Style>
                    <Setter Property="Expander.IsEnabled" Value="False" />
                    <Setter Property="Expander.IsExpanded" Value="False" />
                    <Style.Triggers>
                        <DataTrigger Binding="{Binding Path=Flag}" Value="True">
                            <Setter Property="Expander.IsEnabled" Value="True" />
                            <Setter Property="Expander.IsExpanded" Value="True" />
                        </DataTrigger>
                    </Style.Triggers>
                </Style>
            </Expander.Style>
