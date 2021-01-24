    <Style x:Key="WatermarkTextbox" TargetType="{x:Type TextBox}">
                    <Setter Property="BorderBrush" Value="Black"/>
                    <Setter Property="BorderThickness" Value="1"/>
                    <Setter Property="Template">
                        <Setter.Value>
                            <ControlTemplate TargetType="{x:Type TextBox}">
                                <Border Background="{TemplateBinding Background}"
                                        BorderBrush="{TemplateBinding BorderBrush}"
                                        BorderThickness="{TemplateBinding BorderThickness}">
                                    <Grid>
                                        <ScrollViewer x:Name="PART_ContentHost" />
                                        <TextBlock x:Name="TxBlkEmail" Text="Email..." Visibility="Collapsed">
                                        </TextBlock>
                                    </Grid>
                                </Border>
                                <ControlTemplate.Triggers>
                                    <Trigger Property="Text" Value="{x:Null}">
                                        <Trigger.Setters>
                                            <Setter TargetName="TxBlkEmail" Property="Visibility" Value="Visible"/>
                                        </Trigger.Setters>
                                    </Trigger>
                                    <Trigger Property="Text" Value="">
                                        <Trigger.Setters>
                                            <Setter TargetName="TxBlkEmail" Property="Visibility" Value="Visible"/>
                                        </Trigger.Setters>
                                    </Trigger>
    
                                </ControlTemplate.Triggers>
                            </ControlTemplate>
                        </Setter.Value>
                    </Setter>
                </Style>
