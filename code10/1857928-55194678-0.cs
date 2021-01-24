               <MenuItem>
                        <MenuItem.Resources>
                                <Style TargetType="{x:Type MenuItem}">
                                    <Style.Triggers>
                                        <DataTrigger Binding="{Binding STATUS}" Value="Y">
                                            <Setter Property="Header" Value="Enable" />
                                        </DataTrigger>
                                        <DataTrigger Binding="{Binding STATUS}" Value="N">
                                            <Setter Property="Header" Value="Disable" />
                                        </DataTrigger>
                                    </Style.Triggers>
                                </Style>
                           
                        </MenuItem.Resources>
                    </MenuItem>
                       
