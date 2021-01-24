    <TabControl.Resources>
                        <Style TargetType="TabItem">
                            <Setter Property="Template">
                                <Setter.Value>
                                    <ControlTemplate TargetType="TabItem">
                                        <Grid Name="Panel">
                                            <ContentPresenter VerticalAlignment="Center" HorizontalAlignment="Center" ContentSource="Header" Margin="15,20" />
                                        </Grid>
                                   </ControlTemplate>
                                </Setter.Value>
                            </Setter>
                        </Style>                      
     </TabControl.Resources>
