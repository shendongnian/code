                <ribbon:Ribbon.ApplicationMenu>
                <ribbon:RibbonApplicationMenu>
                    <ribbon:RibbonApplicationMenu.Items>
                        <ribbon:RibbonApplicationMenuItem Name="saveSettings" Header="Save Settings" />
                        <ribbon:RibbonApplicationMenuItem IsEnabled="False"/> <!--USELESS-->
                        <ribbon:RibbonApplicationMenuItem IsEnabled="False"/> <!--USELESS-->
                    </ribbon:RibbonApplicationMenu.Items>
                    
                    <ribbon:RibbonApplicationMenu.AuxiliaryPaneContent >
                            <StackPanel Orientation="Vertical" >
                                <GroupBox>
                                    <Label Content="System Settings" />
                                </GroupBox>
                                <StackPanel Orientation="Horizontal">
                                </StackPanel>
                            </StackPanel>
                    </ribbon:RibbonApplicationMenu.AuxiliaryPaneContent>
                </ribbon:RibbonApplicationMenu>
            </ribbon:Ribbon.ApplicationMenu>
