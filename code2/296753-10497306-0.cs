    <DataGridTextColumn x:Name="Column5" Header="{x:Static p:Resources.Waste_perc}" Width="auto">
                                <DataGridTextColumn.Binding>
                                    <Binding Path="Waste" ValidatesOnDataErrors="True" UpdateSourceTrigger="LostFocus">
                                        <Binding.ValidationRules>
                                            <myLib:DecimalRule />
                                        </Binding.ValidationRules>
                                    </Binding>
                                </DataGridTextColumn.Binding>
                            </DataGridTextColumn>
